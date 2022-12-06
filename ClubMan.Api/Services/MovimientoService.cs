using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using Marten;

namespace ClubMan.Api.Services;

public class MovimientoService : IMovimientoService
{
    public IDocumentSession Session { get; }
    public MovimientoSocio Movimiento { get; }
    public virtual Task ProcesaMovimiento(ProcesaMovimientoEvent procesaMovimientoEvent)
    {
        throw new NotImplementedException();
    }

    public MovimientoService(IDocumentSession session, MovimientoSocio movimientoSocio)
    {
        Session = session;
        Movimiento = movimientoSocio;
    }
    
}