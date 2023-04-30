using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using ClubMan.WebApi.Model;


namespace ClubMan.WebApi.Services;

public class AgregarHuespedService : MovimientoService
{
    private readonly ICarnetService _carnetService;

    public AgregarHuespedService(ClubManContext session, MovimientoSocio movimientoSocio, ICarnetService carnetService) : base(session, movimientoSocio)
    {
        _carnetService = carnetService;
    }

    public override async Task ProcesaMovimiento(ProcesaMovimientoEvent procesaMovimientoEvent)
    {
        Movimiento.Estatus = procesaMovimientoEvent.Estatus;
        Movimiento.RevisadoPor = procesaMovimientoEvent.UserName;
        Movimiento.FechaRevision = DateTime.Today;
        Movimiento.Comentario = procesaMovimientoEvent.Comentario;
        //
        var socio = await Session.FindAsync<Socio>(Movimiento.SocioId);
        var huesped = socio.Huespededes.FirstOrDefault(x => x.MovimientoId == Movimiento.ReferenciaId);
        huesped.Estatus = procesaMovimientoEvent.Estatus;
        if (procesaMovimientoEvent.Estatus == EstatusMovimiento.Aprobado &&
            String.IsNullOrEmpty(huesped.NumeroCarnet))
        {
            await _carnetService.ActivaCarnetHuesped(Session, socio, huesped);
        }
        // Session.Store(socio);
        // Session.Store(Movimiento);
    }
}

public class QuitarHuespedService : MovimientoService
{
    private readonly ICarnetService _carnetService;

    public QuitarHuespedService(ClubManContext session, MovimientoSocio movimientoSocio, ICarnetService carnetService) : base(session, movimientoSocio)
    {
        _carnetService = carnetService;
    }

    public override async Task ProcesaMovimiento(ProcesaMovimientoEvent procesaMovimientoEvent)
    {
        Movimiento.Estatus = procesaMovimientoEvent.Estatus;
        Movimiento.RevisadoPor = procesaMovimientoEvent.UserName;
        Movimiento.FechaRevision = DateTime.Today;
        Movimiento.Comentario = procesaMovimientoEvent.Comentario;
        //
        if (procesaMovimientoEvent.Estatus == EstatusMovimiento.Aprobado)
        {
            var socio = await Session.FindAsync<Socio>(Movimiento.SocioId);
            var huesped = socio.Huespededes.FirstOrDefault(x => x.MovimientoId == Movimiento.ReferenciaId);
            huesped.Estatus = EstatusMovimiento.Rechazado;
            //
            await _carnetService.InactivaCarnetHuesped(Session, socio, huesped);
            //
            // Session.Store(socio);
        }
        // Session.Store(Movimiento);
    }
}