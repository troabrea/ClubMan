using ClubMan.Shared.Model;
using ClubMan.Shared.ViewModel;
using ClubMan.Web.Components;

namespace ClubMan.Web.Services;

public interface IApiService
{
    
    Task<List<Noticia>> GetNoticias(string apiKey);
    Task<List<Noticia>> GetAllNoticias(string apiKey);
    Task<List<Servicio>> GetServicios(string apiKey);
    Task<List<Localidad>> GetLocalidades(string apiKey);
    Task<List<InstalacionViewModel>> GetInstalaciones(string apiKey);
    Task<List<ActividadViewModel>> GetActividades(string apiKey);
    Task<Empresa> GetPreferencias(string apiKey);
    Task UpsertPreferencias(string apiKey, Empresa empresa);
    
    Task<Politica> GetPoliticas(string apiKey);
    Task UpsertPoliticas(string apiKey, Politica politica);
    
    Task<List<Usuario>> GetUsuarios(string apiKey);
    Task UpsertUsuario(string apiKey, Usuario usuario);
    
    Task UpsertLocalidad(string apiKey, Localidad localidad);
    Task RemoveLocalidad(string apiKey, Guid localidadId);
    
    Task UpsertServicio(string apiKey, Servicio servicio);
    Task RemoveServicio(string apiKey, Guid servicioId);
    Task UpsertInstalacion(string apiKey, Instalacion instalacion);
    Task RemoveInstalacion(string apiKey, Guid instalacionId);
    Task UpsertNoticia(string apiKey, Noticia noticia);
    Task RemoveNoticia(string apiKey, Guid noticiaId);
    Task UpsertActividad(string apiKey, Actividad actividad);
    Task RemoveActividad(string apiKey, Guid actividadId);
    Task<List<Solicitud>> GetAllSolicitudes(string apiKey);
    Task<List<Solicitud>> GetSolicitudes(string apiKey);
    Task<Solicitud> GetSolicitud(string apiKey, long solicitudId);
    Task<Solicitud> SubmitSolicitud(AppState appState, long solicitudId);
    Task UpsertSolicitud(string apiKey, Solicitud solicitud);
    Task<Solicitud> RejectReview(AppState appState, long solicitudId, Revision review);
    Task<Solicitud> PostponeReview(AppState appState, long solicitudId, Revision review);
}