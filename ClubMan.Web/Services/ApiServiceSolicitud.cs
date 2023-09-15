using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using ClubMan.Web.Components;

namespace ClubMan.Web.Services;

public partial class ApiService : IApiService
{
    public Task<List<Solicitud>> GetSolicitudes(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<Solicitud>>("Solicitud");
    }
    public Task<List<Solicitud>> GetAllSolicitudes(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<Solicitud>>("Solicitud/all");
    }
    public Task<Solicitud> GetSolicitud(string apiKey, long solicitudId)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<Solicitud>($"Solicitud/{solicitudId}");
    }
    public Task<List<Solicitud>> GetSolicitudesPrevias(string apiKey, string beneficiarioId)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<Solicitud>>($"Solicitud/beneficiario/{beneficiarioId}");
    }
    public async Task<long> CreateSolicitud(string apiKey)
    {
        SetupClient(apiKey);
        var solicitud = Solicitud.Empty();
        await _httpClient.PostAsJsonAsync("Solicitud", solicitud);
        var sols = await GetAllSolicitudes(apiKey);
        return sols.LastOrDefault()?.Id ?? -1;
    }
    public Task InsertSolicitud(string apiKey, Solicitud solicitud)
    {
        SetupClient(apiKey);
        return _httpClient.PostAsJsonAsync("Solicitud", solicitud);
    }
    public Task UpdateSolicitud(string apiKey, Solicitud solicitud)
    {
        SetupClient(apiKey);
        return _httpClient.PutAsJsonAsync("Solicitud", solicitud);
    }
    public async Task<Solicitud> SubmitSolicitud(AppState appState, long solicitudId)
    {
        SetupClient(appState.ClubKey);
        var req = new SometerSolicitudEvent(solicitudId, appState.UserName, DateTime.Today);
        await _httpClient.PostAsJsonAsync("Solicitud/submit", req);
        return await _httpClient.GetFromJsonAsync<Solicitud>($"Solicitud/{solicitudId}");
    }
    public async Task<Solicitud> RejectReview(AppState appState, long solicitudId, Revision review)
    {
        SetupClient(appState.ClubKey);
        var req = new RechazarSolicitudEvent(solicitudId, appState.UserName, review.Observaciones,
            review.FechaRevision);
        await _httpClient.PostAsJsonAsync("Solicitud/reject", req);
        return await _httpClient.GetFromJsonAsync<Solicitud>($"Solicitud/{solicitudId}");
    }
    public async Task<Solicitud> ApproveReview(AppState appState, long solicitudId, Revision review)
    {
        SetupClient(appState.ClubKey);
        var req = new AprobarSolicitudEvent(solicitudId, appState.UserName, review.Observaciones,
            review.FechaRevision, review.NumeroAprobacion, review.CantidadAcciones, review.Valoracciones);
        await _httpClient.PostAsJsonAsync("Solicitud/approve", req);
        return await _httpClient.GetFromJsonAsync<Solicitud>($"Solicitud/{solicitudId}");
    }
    public async Task<Solicitud> PostponeReview(AppState appState, long solicitudId, Revision review)
    {
        SetupClient(appState.ClubKey);
        var req = new PostponerSolicitudEvent(solicitudId, appState.UserName, review.Observaciones,
            review.FechaRevision);
        await _httpClient.PostAsJsonAsync("Solicitud/postpone", req);
        return await _httpClient.GetFromJsonAsync<Solicitud>($"Solicitud/{solicitudId}");
    }

    public async Task<Solicitud> UpdateSolicitudMainPhoto(AppState appState, long solicitudId, string fotoUrl)
    {
        SetupClient(appState.ClubKey);
        var req = new ActualizarFotoPrincipalEvent(solicitudId, fotoUrl);
        await _httpClient.PostAsJsonAsync("Solicitud/updateMainPhoto", req);
        return await _httpClient.GetFromJsonAsync<Solicitud>($"Solicitud/{solicitudId}");
    }

    public async Task<Solicitud> UpdateSolicitudDependientePhoto(AppState appState, long solicitudId, Guid dependienteId, string fotoUrl)
    {
        SetupClient(appState.ClubKey);
        var req = new ActualizarFotoDependienteEvent(solicitudId, dependienteId, fotoUrl);
        await _httpClient.PostAsJsonAsync("Solicitud/updateSecondaryPhoto", req);
        return await _httpClient.GetFromJsonAsync<Solicitud>($"Solicitud/{solicitudId}");
    }
}