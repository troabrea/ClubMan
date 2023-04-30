using ClubMan.Shared.Model;
using ClubMan.WebApi.Model;


namespace ClubMan.WebApi.Services;

public static class MovimientoServiceFactory
{
    public static IMovimientoService GetService(TipoMovimiento tipoMovimiento, ClubManContext session, MovimientoSocio movimientoSocio, ICarnetService carnetService)
    {
        return tipoMovimiento switch
        {
            TipoMovimiento.AgregarAdicional => new AgregarAdicionalService(session, movimientoSocio),
            TipoMovimiento.QuitarAdicional => new QuitarAdicionalService(session, movimientoSocio),
            TipoMovimiento.AgregarDependiente => new AgregarDependienteService(session, movimientoSocio, carnetService),
            TipoMovimiento.QuitarDependiente => new QuitarDependienteService(session, movimientoSocio, carnetService),
            TipoMovimiento.SolicitarActividad => new SolicitarActividadService(session, movimientoSocio),
            TipoMovimiento.SolicitarHuesped => new AgregarHuespedService(session, movimientoSocio, carnetService),
            TipoMovimiento.QuitarHuesped => new QuitarHuespedService(session, movimientoSocio, carnetService),
            _ => new MovimientoService(session, movimientoSocio)
        };
    }
}