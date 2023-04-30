using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using ClubMan.WebApi.Model;


namespace ClubMan.WebApi.Services;

public class MovimientoService : IMovimientoService
{
    public ClubManContext Session { get; }
    public MovimientoSocio Movimiento { get; }
    public virtual Task ProcesaMovimiento(ProcesaMovimientoEvent procesaMovimientoEvent)
    {
        throw new NotImplementedException();
    }

    public MovimientoService(ClubManContext session, MovimientoSocio movimientoSocio)
    {
        Session = session;
        Movimiento = movimientoSocio;
    }
    
}