using ClubMan.Shared.Model;
using ClubMan.WebApi.Model;
using Microsoft.EntityFrameworkCore;


namespace ClubMan.WebApi.Services;

public class CarnetService : ICarnetService
{
    public Task CreateInitialCarnets(ClubManContext session, Socio socio)
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
                Tipo = TipoCarnet.Dependiente,
                NumeroIdentidad = dep.NumeroIdentidad ?? dep.NumeroCarnet,
                Desde = socio.FechaMembresia,
                Estatus = EstatusCarnet.Activo,
                Nombre = dep.Nombre,
                CarnetId = dep.NumeroCarnet,
                FotoUrl = dep.FotoUrl,
                ReferenciaId = dep.Id,
                DiasValidez = 0
            });
        }
        session.AddRange(carnets);

        return Task.CompletedTask;
    }

    public async Task ActivaCarnetMembresia(ClubManContext session, Socio socio)
    {
        var carnet = await session.FindAsync<Carnet>(socio.NumeroCarnet);
        if (carnet != null)
        {
            carnet.Estatus = EstatusCarnet.Activo;
            //session.Add(carnet);
        }
    }

    public async Task InactivaCarnetMembresia(ClubManContext session, Socio socio)
    {
        var carnet = await session.FindAsync<Carnet>(socio.NumeroCarnet);
        if (carnet != null)
        {
            carnet.Estatus = EstatusCarnet.Bloqueado;
            // session.Store(carnet);
        }

    }

    public async Task ActivaCarnetDependiente(ClubManContext session, Socio socio, DependienteSocio dependienteSocio)
    {
        if (String.IsNullOrEmpty(dependienteSocio.NumeroCarnet))
        {
            dependienteSocio.NumeroCarnet = $"{socio.NumeroCarnet}-{dependienteSocio.Id}";
        }
        var carnet = await session.FindAsync<Carnet>(dependienteSocio.NumeroCarnet);
        if (carnet == null)
        {
            carnet = new Carnet()
            {
                Tipo = TipoCarnet.Dependiente,
                SocioId = socio.Id,
                ReferenciaId = dependienteSocio.Id,
                Nombre = dependienteSocio.Nombre,
                NumeroIdentidad = dependienteSocio.NumeroIdentidad ?? dependienteSocio.NumeroCarnet,
                Desde = DateTime.Today,
                Estatus = EstatusCarnet.Activo,
                CarnetId = dependienteSocio.NumeroCarnet,
                DiasValidez = 0,
                FotoUrl = dependienteSocio.FotoUrl
            };
            session.Add(carnet);
        }
        else
        {
            carnet.Estatus = EstatusCarnet.Activo;
        }
        //session.Store(carnet);
    }

    public async Task InactivaCarnetDependiente(ClubManContext session, Socio socio, DependienteSocio dependienteSocio)
    {
        var carnet = await session.FindAsync<Carnet>(dependienteSocio.NumeroCarnet);
        if (carnet != null)
        {
            carnet.Estatus = EstatusCarnet.Bloqueado;
            //session.Store(carnet);
        }
    }
    
    public async Task ActivaCarnetHuesped(ClubManContext session, Socio socio, HuespedSocio huespedSocio)
    {
        if (String.IsNullOrEmpty(huespedSocio.NumeroCarnet))
        {
            huespedSocio.NumeroCarnet = $"{socio.NumeroCarnet}-H-{huespedSocio.Id}";
        }
        var carnet = await session.FindAsync<Carnet>(huespedSocio.NumeroCarnet);
        if (carnet == null)
        {
            carnet = new Carnet()
            {
                Tipo = TipoCarnet.Huesped,
                SocioId = socio.Id,
                ReferenciaId = huespedSocio.Id,
                Nombre = huespedSocio.Nombre,
                NumeroIdentidad = huespedSocio.NumeroIdentidad ?? huespedSocio.NumeroCarnet,
                Desde = DateTime.Today,
                Estatus = EstatusCarnet.Activo,
                CarnetId = huespedSocio.NumeroCarnet,
                DiasValidez = 0,
                FotoUrl = huespedSocio.FotoUrl
            };
            session.Add(carnet);
        }
        else
        {
            carnet.Estatus = EstatusCarnet.Activo;
        }
        //session.Store(carnet);
    }

    public async Task InactivaCarnetHuesped(ClubManContext session, Socio socio, HuespedSocio huespedSocio)
    {
        var carnet = await session.Carnets.Where( x=> x.CarnetId == huespedSocio.NumeroCarnet).FirstOrDefaultAsync();
        if (carnet != null)
        {
            carnet.Estatus = EstatusCarnet.Bloqueado;
            //session.Store(carnet);
        }
    }
    
    public async Task ExpiraCarnetHuesped(ClubManContext session, Socio socio, HuespedSocio huespedSocio)
    {
        var carnet = await session.Carnets.Where( x=> x.CarnetId == huespedSocio.NumeroCarnet).FirstOrDefaultAsync();
        if (carnet != null)
        {
            carnet.Estatus = EstatusCarnet.Expirado;
            //session.Store(carnet);
        }
    }
}