using ClubMan.Shared.Model;

namespace ClubMan.Web.Services;

public partial class ApiService : IApiService
{
    public Task<List<Visitas>> GetResumenVisitas(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<Visitas>>($"Visitas");
    }

    public Task<VisitasSocio> GetVisitasDeSocio(string apiKey, long socioId)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<VisitasSocio>($"Visitas/socio/{socioId}");
    }
}