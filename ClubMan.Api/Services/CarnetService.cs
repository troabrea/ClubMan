using ClubMan.Shared.Model;
using Marten;

namespace ClubMan.Api.Services;

public class CarnetService : ICarnetService
{
    public async Task CreateInitialCarnets(IDocumentSession session, Socio socio)
    {
        List<Carnet> carnets = new List<Carnet>();
        carnets.Add( new Carnet()
        {
            SocioId = socio.Id,
            Tipo = TipoCarnet.Principal,
            NumeroIdentidad = socio.NumeroIdentidad,
            Desde = socio.FechaMembresia,
            Estatus = EstatusCarnet.Activo,
            Nombre = socio.Nombre,
            CarnetId = socio.NumeroCarnet,
            FotoUrl = socio.FotoUrl,
            ReferenciaId = 0,
            DiasValidez = 0
        });
        foreach (var dep in socio.Dependientes)
        {
            carnets.Add( new Carnet()
            {
                SocioId = socio.Id,
                Tipo = TipoCarnet.Principal,
                NumeroIdentidad = dep.NumeroIndentidad ?? dep.NumeroCarnet,
                Desde = socio.FechaMembresia,
                Estatus = EstatusCarnet.Activo,
                Nombre = dep.Nombre,
                CarnetId = dep.NumeroCarnet,
                FotoUrl = dep.FotoUrl,
                ReferenciaId = dep.Id,
                DiasValidez = 0
            });
        }
        session.Store<Carnet>(carnets);
    }

    public async Task ActivaCarnetMembresia(IDocumentSession session, Socio socio)
    {
        var carnet = await session.LoadAsync<Carnet>(socio.NumeroCarnet);
        if (carnet != null)
        {
            carnet.Estatus = EstatusCarnet.Activo;
            session.Store(carnet);
        }
    }

    public async Task InactivaCarnetMembresia(IDocumentSession session, Socio socio)
    {
        var carnet = await session.LoadAsync<Carnet>(socio.NumeroCarnet);
        if (carnet != null)
        {
            carnet.Estatus = EstatusCarnet.Bloqueado;
            session.Store(carnet);
        }

    }

    public async Task ActivaCarnetDependiente(IDocumentSession session, Socio socio, DependienteSocio dependienteSocio)
    {
        if (String.IsNullOrEmpty(dependienteSocio.NumeroCarnet))
        {
            dependienteSocio.NumeroCarnet = $"{socio.NumeroCarnet}-{dependienteSocio.Id}";
        }
        var carnet = await session.LoadAsync<Carnet>(dependienteSocio.NumeroCarnet);
        if (carnet == null)
        {
            carnet = new Carnet()
            {
                Tipo = TipoCarnet.Dependiente,
                SocioId = socio.Id,
                ReferenciaId = dependienteSocio.Id,
                Nombre = dependienteSocio.Nombre,
                NumeroIdentidad = dependienteSocio.NumeroIndentidad ?? dependienteSocio.NumeroCarnet,
                Desde = DateTime.Today,
                Estatus = EstatusCarnet.Activo,
                CarnetId = dependienteSocio.NumeroCarnet,
                DiasValidez = 0,
                FotoUrl = dependienteSocio.FotoUrl
            };
        }
        else
        {
            carnet.Estatus = EstatusCarnet.Activo;
        }
        session.Store(carnet);
    }

    public async Task InactivaCarnetDependiente(IDocumentSession session, Socio socio, DependienteSocio dependienteSocio)
    {
        var carnet = await session.LoadAsync<Carnet>(dependienteSocio.NumeroCarnet);
        if (carnet != null)
        {
            carnet.Estatus = EstatusCarnet.Bloqueado;
            session.Store(carnet);
        }
    }
}