using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using Marten;

namespace ClubMan.Api.Services;

public class AgregarDependienteService : MovimientoService
{
    private readonly ICarnetService _carnetService;

    public AgregarDependienteService(IDocumentSession session, MovimientoSocio movimientoSocio, ICarnetService carnetService) : base(session, movimientoSocio)
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
        var socio = await Session.LoadAsync<Socio>(Movimiento.SocioId);
        var dependiente = socio.Dependientes.FirstOrDefault(x => x.MovimientoId == Movimiento.ReferenciaId);
        dependiente.Estatus = procesaMovimientoEvent.Estatus;
        if (procesaMovimientoEvent.Estatus == EstatusMovimiento.Aprobado &&
            String.IsNullOrEmpty(dependiente.NumeroCarnet))
        {
            _carnetService.ActivaCarnetDependiente(Session, socio, dependiente);
        }
        Session.Store(socio);
        Session.Store(Movimiento);
    }
}


public class QuitarDependienteService : MovimientoService
{
    private readonly ICarnetService _carnetService;

    public QuitarDependienteService(IDocumentSession session, MovimientoSocio movimientoSocio, ICarnetService carnetService) : base(session, movimientoSocio)
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
            var socio = await Session.LoadAsync<Socio>(Movimiento.SocioId);
            var dependiente = socio.Dependientes.FirstOrDefault(x => x.MovimientoId == Movimiento.ReferenciaId);
            dependiente.Estatus = EstatusMovimiento.Rechazado;
            //
            _carnetService.InactivaCarnetDependiente(Session, socio, dependiente);
            //
            Session.Store(socio);
        }
        Session.Store(Movimiento);
    }
}


public class SolicitarActividadService : MovimientoService
{
    public SolicitarActividadService(IDocumentSession session, MovimientoSocio movimientoSocio) : base(session, movimientoSocio)
    {
        
    }

    public override async Task ProcesaMovimiento(ProcesaMovimientoEvent procesaMovimientoEvent)
    {
        Movimiento.Estatus = procesaMovimientoEvent.Estatus;
        Movimiento.RevisadoPor = procesaMovimientoEvent.UserName;
        Movimiento.FechaRevision = DateTime.Today;
        Movimiento.Comentario = procesaMovimientoEvent.Comentario;
        //
        var evento = await Session.Query<EventoDeSocio>().Where(x => x.MovimientoId == Movimiento.ReferenciaId)
            .FirstAsync();
        evento.Estatus = procesaMovimientoEvent.Estatus == EstatusMovimiento.Aprobado ? EstatusEvento.Aprobado : EstatusEvento.Rechazado;
        Session.Store(evento);
        Session.Store(Movimiento);
    }
}