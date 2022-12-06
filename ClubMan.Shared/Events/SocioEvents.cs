using ClubMan.Shared.Model;

namespace ClubMan.Shared.Events;

public record AgregarAdicionalEvent(long SocioId, string UserName, AdicionalSocio AdicionalSocio);
public record AgregarDependienteEvent(long SocioId, string UserName, DependienteSocio DependienteSocio);
public record ProcesaMovimientoEvent(long MovimientoId, string UserName, EstatusMovimiento Estatus, string Comentario);

public record SometerEventoEvent(long EventoId, string UserName, DateTime FechaSometimiento);
public record RechazarEventoEvent(long EventoId, string UserName, string Observaciones, DateTime FechaRevision);
public record AprobarEventoEvent(long EventoId, string UserName, string Observaciones, DateTime FechaRevision);
