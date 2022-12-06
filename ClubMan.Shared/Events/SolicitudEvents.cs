namespace ClubMan.Shared.Events;
public record ActualizarFotoPrincipalEvent(long SolicitudId, string FotoUrl);
public record ActualizarFotoDependienteEvent(long SolicitudId, Guid DependienteId, string FotoUrl);
public record SometerSolicitudEvent(long SolicitudId, string UserName, DateTime FechaSometimiento);
public record PostponerSolicitudEvent(long SolicitudId, string UserName, string Observaciones, DateTime FechaRevision);
public record RechazarSolicitudEvent(long SolicitudId, string UserName, string Observaciones, DateTime FechaRevision);

public record AprobarSolicitudEvent(long SolicitudId, string UserName, string Observaciones, DateTime FechaRevision, string NumeroAprobacion, int CantidadAcciones, decimal Valoraciones);
