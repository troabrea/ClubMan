using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using Marten;

namespace ClubMan.Api.Services;

public class AgregarAdicionalService : MovimientoService
{
    public AgregarAdicionalService(IDocumentSession session, MovimientoSocio movimientoSocio) : base(session, movimientoSocio)
    {
    }

    public override async Task ProcesaMovimiento(ProcesaMovimientoEvent procesaMovimientoEvent)
    {
        Movimiento.Estatus = procesaMovimientoEvent.Estatus;
        Movimiento.RevisadoPor = procesaMovimientoEvent.UserName;
        Movimiento.FechaRevision = DateTime.Today;
        Movimiento.Comentario = procesaMovimientoEvent.Comentario;
        //
        var socio = await Session.LoadAsync<Socio>(Movimiento.SocioId);
        var adicional = socio.Adicionales.FirstOrDefault(x => x.MovimientoId == Movimiento.ReferenciaId);
        adicional.Estatus = procesaMovimientoEvent.Estatus;
        Session.Store(socio);
        Session.Store(Movimiento);
    }
}

public class QuitarAdicionalService : MovimientoService
{
    public QuitarAdicionalService(IDocumentSession session, MovimientoSocio movimientoSocio) : base(session, movimientoSocio)
    {
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
            var adicional = socio.Adicionales.FirstOrDefault(x => x.MovimientoId == Movimiento.ReferenciaId);
            adicional.Estatus = EstatusMovimiento.Rechazado;
            Session.Store(socio);
        }
        Session.Store(Movimiento);
    }
}