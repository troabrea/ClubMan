using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using Marten;

namespace ClubMan.Api.Services;

public interface IMovimientoService
{
    IDocumentSession Session { get; }
    MovimientoSocio Movimiento { get; }
    Task ProcesaMovimiento(ProcesaMovimientoEvent procesaMovimientoEvent);
}