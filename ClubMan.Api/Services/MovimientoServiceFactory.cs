using ClubMan.Shared.Model;
using Marten;

namespace ClubMan.Api.Services;

public static class MovimientoServiceFactory
{
    public static IMovimientoService GetService(TipoMovimiento tipoMovimiento, IDocumentSession session, MovimientoSocio movimientoSocio, ICarnetService carnetService)
    {
        return tipoMovimiento switch
        {
            TipoMovimiento.AgregarAdicional => new AgregarAdicionalService(session, movimientoSocio),
            TipoMovimiento.QuitarAdicional => new QuitarAdicionalService(session, movimientoSocio),
            TipoMovimiento.AgregarDependiente => new AgregarDependienteService(session, movimientoSocio, carnetService),
            TipoMovimiento.QuitarDependiente => new QuitarDependienteService(session, movimientoSocio, carnetService),
            TipoMovimiento.SolicitarActividad => new SolicitarActividadService(session, movimientoSocio),
            _ => new MovimientoService(session, movimientoSocio)
        };
    }
}