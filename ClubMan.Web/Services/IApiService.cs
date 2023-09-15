using ClubMan.Shared.Dto;
using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using ClubMan.Shared.ViewModel;
using ClubMan.Web.Components;

namespace ClubMan.Web.Services;

public interface IApiService
{
    #region Contenido

    Task<List<Noticia>> GetNoticias(string apiKey);
    Task<List<Noticia>> GetAllNoticias(string apiKey);
    Task<List<Mensaje>> GetMensajes(string apiKey);
    Task<List<Mensaje>> GetAllMensajes(string apiKey);
    Task<List<Pregunta>> GetPreguntas(string apiKey);
    Task<List<Servicio>> GetServicios(string apiKey);
    Task<List<Localidad>> GetLocalidades(string apiKey);
    Task<List<InstalacionViewModel>> GetInstalaciones(string apiKey);
    Task<List<ActividadViewModel>> GetActividades(string apiKey);
    Task UpsertLocalidad(string apiKey, Localidad localidad, bool isNew);
    Task RemoveLocalidad(string apiKey, Guid localidadId);
    
    Task UpsertServicio(string apiKey, Servicio servicio, bool isNew);
    Task RemoveServicio(string apiKey, Guid servicioId);
    Task UpsertPregunta(string apiKey, Pregunta pregunta, bool isNew);
    Task RemovePregunta(string apiKey, Guid preguntaId);
    
    Task UpsertInstalacion(string apiKey, Instalacion instalacion, bool isNew);
    Task RemoveInstalacion(string apiKey, Guid instalacionId);
    Task UpsertNoticia(string apiKey, Noticia noticia, bool isNew);
    Task UpsertMensaje(string apiKey, Mensaje mensaje, bool isNew);
    Task RemoveNoticia(string apiKey, Guid noticiaId);
    Task RemoveMensaje(string apiKey, Guid mensajeId);
    Task UpsertActividad(string apiKey, Actividad actividad, bool isNew);
    Task RemoveActividad(string apiKey, Guid actividadId);

    #endregion

    #region Configuración

    Task<Empresa> GetPreferencias(string apiKey);
    Task UpsertPreferencias(string apiKey, Empresa empresa);

    Task<Politica> GetPoliticas(string apiKey);
    Task UpsertPoliticas(string apiKey, Politica politica);
    Task<List<Usuario>> GetUsuarios(string apiKey);
    Task UpsertUsuario(string apiKey, Usuario usuario, bool isNew);
    Task<List<UsuarioApp>> GetUsuariosApp(string apiKey);
    Task UpsertUsuarioApp(string apiKey, UsuarioApp usuario, bool isNew);

    #endregion

    #region Solicitudes

    Task<List<Solicitud>> GetAllSolicitudes(string apiKey);
    Task<List<Solicitud>> GetSolicitudes(string apiKey);
    Task<Solicitud> GetSolicitud(string apiKey, long solicitudId);
    Task<List<Solicitud>> GetSolicitudesPrevias(string apiKey, string beneficiaio);
    Task<Solicitud> SubmitSolicitud(AppState appState, long solicitudId);
    Task<long> CreateSolicitud(string apiKey);
    Task InsertSolicitud(string apiKey, Solicitud solicitud);
    Task UpdateSolicitud(string apiKey, Solicitud solicitud);
    Task<Solicitud> RejectReview(AppState appState, long solicitudId, Revision review);
    Task<Solicitud> ApproveReview(AppState appState, long solicitudId, Revision review);
    Task<Solicitud> PostponeReview(AppState appState, long solicitudId, Revision review);
    Task<Solicitud> UpdateSolicitudMainPhoto(AppState appState, long solicitudId, string fotoUrl);
    Task<Solicitud> UpdateSolicitudDependientePhoto(AppState appState, long solicitudId, Guid dependienteId, string fotoUrl);

        #endregion

    #region Socio

    Task<List<Socio>> GetSocios(string apiKey);
    Task<Socio> GetSocio(string apiKey, long socioId);
    Task<Socio> UpdateSocioGenerales(string apiKey, Socio socio);
    Task<Socio> UpdateSocioMembresia(string apiKey, Socio socio, TipoSocio nuevoTipoSocio, string nuevoCarnet);
    Task<Socio> UpsertSocioAdicional(AppState appState, long socioId, AdicionalSocio adicionalSocio);
    Task<Socio> ReActivateSocioAdicional(AppState appState, long socioId, AdicionalSocio adicionalSocio);
    Task<Socio> DeActivateSocioAdicional(AppState appState, long socioId, AdicionalSocio adicionalSocio);
    Task<Socio> DeleteAdicional(string apiKey, long socioId, long adicionalId);
    
    Task<Socio> UpsertSocioDependiente(AppState appState, long socioId, DependienteSocio dependienteSocio);
    Task<Socio> ReActivateSocioDependiente(AppState appState, long socioId, DependienteSocio dependienteSocio);
    Task<Socio> DeActivateSocioDependiente(AppState appState, long socioId, DependienteSocio dependienteSocio);
    
    Task<Socio> UpsertSocioHuesped(AppState appState, long socioId, HuespedSocio huespedSocio);
    Task<Socio> ReActivateSocioHuesped(AppState appState, long socioId, HuespedSocio huespedSocio);
    Task<Socio> DeActivateSocioHuesped(AppState appState, long socioId, HuespedSocio huespedSocio);
    
    Task<Socio> UpsertEmbarcacion(string apiKey, long socioId, Embarcacion embarcacion);
    Task<Socio> DeleteEmbarcacion(string apiKey, long socioId, Embarcacion embarcacion);
    Task<List<MovimientoSocio>> GetAprobacionesPendientes(string apiKey);
    Task ProcesaMovimento(string apiKey, ProcesaMovimientoEvent procesaEvent);

    Task<List<FacturaDto>> GetEstadoDeCuenta(string apiKey, long socioId);

    #endregion

    #region EventosDeSocio
    Task<List<EventoViewModel>> GetEventos(string apiKey);
    Task<List<EventoViewModel>> GetEventos(string apiKey, long socioId);
    Task UpsertEvento(string apiKey, EventoDeSocio evento, bool isCreating);
    Task RemoveEvento(string apiKey, long eventoId);

    Task SometerEvento(AppState appState, EventoDeSocio eventoDeSocio);
    Task AprobarEvento(AppState appState, EventoDeSocio eventoDeSocio);
    Task RechazarEvento(AppState appState, EventoDeSocio eventoDeSocio);

    #endregion

    #region Cortesias
    Task<List<Cortesia>> GetCortesias(string apiKey);
    Task UpsertCortesia(string apiKey, Cortesia cortesia, bool isNew);
    Task RemoveCortesia(string apiKey,  long cortesiaId);
    #endregion

    #region Invitaciones

    Task<List<InvitacionDeSocio>> GetInvitacionesSocio(string apiKey, long socioId);

    #endregion

    #region Visitas
    
    Task<List<Visitas>> GetResumenVisitas(string apiKey);
    Task<VisitasSocio> GetVisitasDeSocio(string apiKey, long socioId);

    #endregion

}