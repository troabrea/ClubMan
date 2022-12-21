using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using ClubMan.Shared.ViewModel;
using ClubMan.Web.Components;

namespace ClubMan.Web.Services;

public partial class ApiService : IApiService
{
    public Task<List<EventoViewModel>> GetEventos(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<EventoViewModel>>($"Evento");
    }
    public Task<List<EventoViewModel>> GetEventos(string apiKey, long socioId)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<EventoViewModel>>($"Evento/{socioId}");
    }

    public Task UpsertEvento(string apiKey, EventoDeSocio evento)
    {
        SetupClient(apiKey);
        return _httpClient.PostAsJsonAsync("Evento", evento);
    }

    public Task RemoveEvento(string apiKey, long eventoId)
    {
        SetupClient(apiKey);
        return _httpClient.DeleteAsync($"Evento/{eventoId}");
    }

    public async Task SometerEvento(AppState appState, EventoDeSocio eventoDeSocio)
    {
        SetupClient(appState.ClubKey);
        var agregarEvent = new SometerEventoEvent( eventoDeSocio.Id, appState.UserName, DateTime.Today );
        await _httpClient.PostAsJsonAsync($"Evento/submit", agregarEvent);
    }

    public Task AprobarEvento(AppState appState, EventoDeSocio eventoDeSocio)
    {
        throw new NotImplementedException();
    }

    public Task RechazarEvento(AppState appState, EventoDeSocio eventoDeSocio)
    {
        throw new NotImplementedException();
    }
}