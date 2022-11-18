using System.Diagnostics.CodeAnalysis;
using ClubMan.Shared.Model;
using ClubMan.Shared.ViewModel;

namespace ClubMan.Web.Services;

public class SystemApiService : ISystemApiService
{
    private readonly HttpClient _httpClient;

    public SystemApiService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("system");
    }
    public async Task<LoggedUserViewModel> LoginUser(string usuario, string clave)
    {
        var result = await _httpClient.PostAsJsonAsync<LoginViewModel>("Usuario/login", new LoginViewModel() { UsuarioId = usuario, Clave = clave});
        if (!result.IsSuccessStatusCode)
        {
            return null;
        }
        return await result.Content.ReadFromJsonAsync<LoggedUserViewModel>();
    }

    public Task<Empresa> GetEmpresa(string empresaId)
    {
        return _httpClient.GetFromJsonAsync<Empresa>($"Empresa/{empresaId}");
    }

    public Task<Usuario> GetUsuario(string usuarioId)
    {
        return _httpClient.GetFromJsonAsync<Usuario>($"Usuario/{usuarioId}");
    }

    public async Task UpdateUsuario(Usuario usuario)
    {
        var result = await _httpClient.PostAsJsonAsync<Usuario>("Usuario", usuario);
        result.EnsureSuccessStatusCode();
    }
}