using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using ClubMan.WebApi.Model;


namespace ClubMan.WebApi.Services;

public interface IMovimientoService
{
    ClubManContext Session { get; }
    MovimientoSocio Movimiento { get; }
    Task ProcesaMovimiento(ProcesaMovimientoEvent procesaMovimientoEvent);
}