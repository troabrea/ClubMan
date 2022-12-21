using ClubMan.Shared.Model;

namespace ClubMan.Web.Services;

public partial class ApiService : IApiService
{
    public Task<List<InvitacionDeSocio>> GetInvitacionesSocio(string apiKey, long socioId)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<InvitacionDeSocio>>($"Invitaciones/socio/recientes/{socioId}");
    }
}