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

    public Task<List<Mensaje>> GetMensajes(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<Mensaje>>("Mensaje");
    }

    public Task<List<Mensaje>> GetAllMensajes(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<Mensaje>>("Mensaje/all");
    }

    public Task<List<Servicio>> GetServicios(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<Servicio>>("Servicio");
    }
    public Task<List<Pregunta>> GetPreguntas(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<Pregunta>>("Pregunta");
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

    public Task UpsertUsuario(string apiKey, Usuario usuario, bool isNew)
    {
        SetupClient(apiKey);
        return isNew ? _httpClient.PostAsJsonAsync("Admin/Usuarios", usuario) : _httpClient.PutAsJsonAsync("Admin/Usuarios", usuario);
    }
    
    public Task<List<UsuarioApp>> GetUsuariosApp(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<UsuarioApp>>($"UsuarioApp");
    }

    public Task UpsertUsuarioApp(string apiKey, UsuarioApp usuario, bool isNew)
    {
        SetupClient(apiKey);
        return isNew ? _httpClient.PostAsJsonAsync("UsuarioApp", usuario) : _httpClient.PutAsJsonAsync("UsuarioApp", usuario);
    }
    
    public Task UpsertLocalidad(string apiKey, Localidad localidad, bool isNew)
    {
        SetupClient(apiKey);
        return isNew ? _httpClient.PostAsJsonAsync("Localidad", localidad) : _httpClient.PutAsJsonAsync("Localidad", localidad);
    }

    public Task RemoveLocalidad(string apiKey, Guid localidadId)
    {
        SetupClient(apiKey);
        return _httpClient.DeleteAsync($"Localidad/{localidadId}");
    }

    public Task UpsertServicio(string apiKey, Servicio servicio, bool isNew)
    {
        SetupClient(apiKey);
        return isNew ? _httpClient.PostAsJsonAsync("Servicio", servicio) : _httpClient.PutAsJsonAsync("Servicio", servicio);
    }

    public Task RemoveServicio(string apiKey, Guid servicioId)
    {
        SetupClient(apiKey);
        return _httpClient.DeleteAsync($"Servicio/{servicioId}");
    }
    public Task UpsertPregunta(string apiKey, Pregunta pregunta, bool isNew)
    {
        SetupClient(apiKey);
        return isNew ? _httpClient.PostAsJsonAsync("Pregunta", pregunta) : _httpClient.PutAsJsonAsync("Pregunta", pregunta);
    }

    public Task RemovePregunta(string apiKey, Guid preguntaId)
    {
        SetupClient(apiKey);
        return _httpClient.DeleteAsync($"Pregunta/{preguntaId}");
    }
    public Task UpsertNoticia(string apiKey, Noticia noticia, bool isNew)
    {
        SetupClient(apiKey);
        return isNew ? _httpClient.PostAsJsonAsync("Noticia", noticia) : _httpClient.PutAsJsonAsync("Noticia", noticia);
    }

    public Task UpsertMensaje(string apiKey, Mensaje mensaje, bool isNew)
    {
        SetupClient(apiKey);
        return isNew ? _httpClient.PostAsJsonAsync("Mensaje", mensaje) : _httpClient.PutAsJsonAsync("Mensaje", mensaje);
    }

    public Task RemoveNoticia(string apiKey, Guid noticiaId)
    {
        SetupClient(apiKey);
        return _httpClient.DeleteAsync($"Noticia/{noticiaId}");
    }

    public Task RemoveMensaje(string apiKey, Guid mensajeId)
    {
        SetupClient(apiKey);
        return _httpClient.DeleteAsync($"Mensaje/{mensajeId}");
    }

    public Task UpsertInstalacion(string apiKey, Instalacion instalacion, bool isNew)
    {
        SetupClient(apiKey);
        return isNew ? _httpClient.PostAsJsonAsync("Instalacion", instalacion) : _httpClient.PutAsJsonAsync("Instalacion", instalacion);
    }

    public Task RemoveInstalacion(string apiKey, Guid instalacionId)
    {
        SetupClient(apiKey);
        return _httpClient.DeleteAsync($"Instalacion/{instalacionId}");
    }
    
    public Task UpsertActividad(string apiKey, Actividad actividad, bool isNew)
    {
        SetupClient(apiKey);
        return isNew ? _httpClient.PostAsJsonAsync("Actividad", actividad) : _httpClient.PutAsJsonAsync("Actividad", actividad);
    }

    public Task RemoveActividad(string apiKey, Guid actividadId)
    {
        SetupClient(apiKey);
        return _httpClient.DeleteAsync($"Actividad/{actividadId}");
    }
}