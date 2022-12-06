using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using ClubMan.Shared.ViewModel;
using ClubMan.Web.Components;
using Microsoft.Net.Http.Headers;

namespace ClubMan.Web.Services;

public partial class ApiService : IApiService
{
    private readonly HttpClient _httpClient;

    void SetupClient(string apiKey)
    {
        if (_httpClient.DefaultRequestHeaders.Contains(HeaderNames.Authorization))
            _httpClient.DefaultRequestHeaders.Remove(HeaderNames.Authorization);
        _httpClient.DefaultRequestHeaders.Add(HeaderNames.Authorization,$"Bearer {apiKey}");
    }
    
    public ApiService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("api");
    }

    public Task<List<Noticia>> GetNoticias(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<Noticia>>("Noticia");
    }
    public Task<List<Noticia>> GetAllNoticias(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<Noticia>>("Noticia/all");
    }
    public Task<List<Servicio>> GetServicios(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<Servicio>>("Servicio");
    }

    public Task<List<Localidad>> GetLocalidades(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<Localidad>>("Localidad");
    }

    public Task<List<InstalacionViewModel>> GetInstalaciones(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<InstalacionViewModel>>("Instalacion");
    }

    public async Task<List<ActividadViewModel>> GetActividades(string apiKey)
    {
        SetupClient(apiKey);
        var result = await _httpClient.GetFromJsonAsync<List<ActividadViewModel>>("Actividad");
        return result;
    }
    

    
    public Task<Empresa> GetPreferencias(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<Empresa>($"Admin/Preferencias");
    }

    public Task UpsertPreferencias(string apiKey, Empresa empresa)
    {
        SetupClient(apiKey);
        return _httpClient.PostAsJsonAsync("Admin/Preferencias", empresa);
    }

    public Task<Politica> GetPoliticas(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<Politica>($"Admin/Politicas");
    }

    public Task UpsertPoliticas(string apiKey, Politica politica)
    {
        SetupClient(apiKey);
        return _httpClient.PostAsJsonAsync("Admin/Politicas", politica);
    }

    public Task<List<Usuario>> GetUsuarios(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<Usuario>>($"Admin/Usuarios");
    }

    public Task UpsertUsuario(string apiKey, Usuario usuario)
    {
        SetupClient(apiKey);
        return _httpClient.PostAsJsonAsync("Admin/Usuarios", usuario);
    }

    public Task UpsertLocalidad(string apiKey, Localidad localidad)
    {
        SetupClient(apiKey);
        return _httpClient.PostAsJsonAsync("Localidad", localidad);
    }

    public Task RemoveLocalidad(string apiKey, Guid localidadId)
    {
        SetupClient(apiKey);
        return _httpClient.DeleteAsync($"Localidad/{localidadId}");
    }

    public Task UpsertServicio(string apiKey, Servicio servicio)
    {
        SetupClient(apiKey);
        return _httpClient.PostAsJsonAsync("Servicio", servicio);
    }

    public Task RemoveServicio(string apiKey, Guid servicioId)
    {
        SetupClient(apiKey);
        return _httpClient.DeleteAsync($"Servicio/{servicioId}");
    }

    public Task UpsertNoticia(string apiKey, Noticia noticia)
    {
        SetupClient(apiKey);
        return _httpClient.PostAsJsonAsync("Noticia", noticia);
    }

    public Task RemoveNoticia(string apiKey, Guid noticiaId)
    {
        SetupClient(apiKey);
        return _httpClient.DeleteAsync($"Noticia/{noticiaId}");
    }
    
    public Task UpsertInstalacion(string apiKey, Instalacion instalacion)
    {
        SetupClient(apiKey);
        return _httpClient.PostAsJsonAsync("Instalacion", instalacion);
    }

    public Task RemoveInstalacion(string apiKey, Guid instalacionId)
    {
        SetupClient(apiKey);
        return _httpClient.DeleteAsync($"Instalacion/{instalacionId}");
    }
    
    public Task UpsertActividad(string apiKey, Actividad actividad)
    {
        SetupClient(apiKey);
        return _httpClient.PostAsJsonAsync("Actividad", actividad);
    }

    public Task RemoveActividad(string apiKey, Guid actividadId)
    {
        SetupClient(apiKey);
        return _httpClient.DeleteAsync($"Actividad/{actividadId}");
    }
}