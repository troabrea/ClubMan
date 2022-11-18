namespace ClubMan.Shared.Events;

public record SometerSolicitudEvent(long SolicitudId, string UserName, DateTime FechaSometimiento);
public record PostponerSolicitudEvent(long SolicitudId, string UserName, string Observaciones, DateTime FechaRevision);
public record RechazarSolicitudEvent(long SolicitudId, string UserName, string Observaciones, DateTime FechaRevision);
