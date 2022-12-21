using System.Xml.XPath;
using ClubMan.Api.Services;
using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using Marten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.Api.Controllers;

[ApiController]
[Authorize(Roles = "User")]
[Route("api/[controller]")]
public class SocioController : TenantController
{
    private readonly ILogger<SocioController> _logger;

    public SocioController(ILogger<SocioController> logger, IDocumentStore store,
        IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor, store)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetSocios")]
    public async Task<IReadOnlyList<Socio>> Get()
    {
        using var session = _store.OpenSession(TenantId);
        return await session.Query<Socio>().Where(x => x.EstatusMembresia == EstatusMembresia.Activa).ToListAsync();
    }

    [HttpGet( "{socioId:long}", Name = "GetSocio")]
    public async Task<Socio> GetById(long socioId)
    {
        using var session = _store.OpenSession(TenantId);
        return await session.LoadAsync<Socio>(socioId);
    }
    
    [HttpGet("all", Name = "GetAllSocios")]
    public async Task<IReadOnlyList<Socio>> GetAll()
    {
        using var session = _store.OpenSession(TenantId);
        return await session.Query<Socio>().ToListAsync();
    }

    [HttpPost("generales", Name = "UpdateGeneralesSocio")]
    public async Task<Socio> UpdateDatosGenerales(Socio _socio)
    {
        using var session = _store.OpenSession(TenantId);
        var socio = await session.LoadAsync<Socio>(_socio.Id);
        //
        socio.EstadoCivil = _socio.EstadoCivil;
        socio.NumeroFiscal = _socio.NumeroFiscal;
        socio.Nacionalidad = _socio.Nacionalidad;
        socio.Direccion = _socio.Direccion;
        socio.Sector = _socio.Sector;
        socio.Ciudad = _socio.Ciudad;
        socio.Pais = _socio.Pais;
        socio.TelefonoResidencia = _socio.TelefonoResidencia;
        socio.Celular = _socio.Celular;
        socio.Email = _socio.Email;
        socio.LugarTrabajo = _socio.LugarTrabajo;
        socio.Posicion = _socio.Posicion;
        socio.TelefonoOficina = _socio.TelefonoOficina;
        socio.TelefonoFlota = _socio.TelefonoFlota;
        socio.EmailTrabajo = _socio.EmailTrabajo;
        socio.NombreAsistente = _socio.NombreAsistente;
        socio.EmailAsitente = _socio.EmailAsitente;
        //
        session.Store(socio);
        await session.SaveChangesAsync();
        return socio;
    }
    
    #region Adicionales

    [HttpPost("adicional/{socioId:long}", Name = "AddOrUpdateAdicionalDeSocio")]
    public async Task<ActionResult<Socio>> AddOrUpdateAdicional(long socioId, AgregarAdicionalEvent agregarAdicionalEvent)
    {
        var adicionalSocio = agregarAdicionalEvent.AdicionalSocio;
        using var session = _store.OpenSession(TenantId);
        var socio = await session.LoadAsync<Socio>(socioId);
        if (socio == null) return BadRequest("Socio inválido");
        var adicional = socio.Adicionales.FirstOrDefault(x => x.Id == adicionalSocio.Id);
        if (adicional == null)
        {
            var refId = Guid.NewGuid();
            var newid = socio.Adicionales.Any() ? socio.Adicionales.Max(x => x.Id) + 1 : 1;
            adicional = adicionalSocio with
            {
                Id = newid,
                MovimientoId = refId
            };
            socio.Adicionales.Add(adicional);
            //
            var mov = new MovimientoSocio
            {
                SocioId = socio.Id,
                ReferenciaId = refId,
                TipoMovimiento = TipoMovimiento.AgregarAdicional,
                Estatus = EstatusMovimiento.Pendiente,
                FechaRegistro = DateTime.Today,
                RegistradaPor = agregarAdicionalEvent.UserName,
                Nota =
                    $"El socio {socio.NumeroCarnet} - {socio.Nombre}, desea agregar a {adicional.Nombre} como un adicional a su membresía."
            };
            //
            session.Store( mov );
        }
        else
        {
            socio.Adicionales.Remove(adicional);
            socio.Adicionales.Add(adicionalSocio);
        }
        session.Store(socio);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost("adicional/activar", Name = "ReactivarAdicionalDeSocio")]
    public async Task<ActionResult<Socio>> ReactivateAdicional(AgregarAdicionalEvent agregarAdicionalEvent)
    {
        using var session = _store.OpenSession(TenantId);
        var socio = await session.LoadAsync<Socio>(agregarAdicionalEvent.SocioId);
        if (socio == null) return BadRequest("Socio inválido");
        var adicional = socio.Adicionales.FirstOrDefault(x => x.Id == agregarAdicionalEvent.AdicionalSocio.Id);
        if (adicional == null || adicional.Estatus != EstatusMovimiento.Rechazado)
        {
            return BadRequest("Adicional inválido");
        }
        var refId = Guid.NewGuid();
        var mov = new MovimientoSocio
        {
            SocioId = socio.Id,
            ReferenciaId = refId,
            TipoMovimiento = TipoMovimiento.AgregarAdicional,
            Estatus = EstatusMovimiento.Pendiente,
            FechaRegistro = DateTime.Today,
            RegistradaPor = agregarAdicionalEvent.UserName,
            Nota =
                $"El socio {socio.NumeroCarnet} - {socio.Nombre}, desea activar a {adicional.Nombre} como un adicional a su membresía."
        };
        adicional.Estatus = EstatusMovimiento.Pendiente;
        adicional.MovimientoId = refId;
        session.Store(socio);
        session.Store(mov);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost("adicional/cancelar", Name = "RemoveAdicionalDeSocio")]
    public async Task<ActionResult<Socio>> RemoveAdicional(AgregarAdicionalEvent agregarAdicionalEvent)
    {
        using var session = _store.OpenSession(TenantId);
        var socio = await session.LoadAsync<Socio>(agregarAdicionalEvent.SocioId);
        if (socio == null) return BadRequest("Socio inválido");
        var adicional = socio.Adicionales.FirstOrDefault(x => x.Id == agregarAdicionalEvent.AdicionalSocio.Id);
        if (adicional == null || adicional.Estatus != EstatusMovimiento.Aprobado)
        {
            return BadRequest("Adicional inválido");
        }

        var refId = Guid.NewGuid();
        var mov = new MovimientoSocio
        {
            SocioId = socio.Id,
            ReferenciaId = refId,
            TipoMovimiento = TipoMovimiento.QuitarAdicional,
            Estatus = EstatusMovimiento.Pendiente,
            FechaRegistro = DateTime.Today,
            RegistradaPor = agregarAdicionalEvent.UserName,
            Nota =
                $"El socio {socio.NumeroCarnet} - {socio.Nombre}, desea remover a {adicional.Nombre} como un adicional a su membresía."
        };
        adicional.MovimientoId = refId;
        session.Store(mov);
        session.Store(socio);
        await session.SaveChangesAsync();
        return Ok();
    }

    #endregion

    #region Dependientes

    [HttpPost("dependiente/{socioId:long}", Name = "AddOrUpdateDependienteDeSocio")]
    public async Task<ActionResult<Socio>> AddOrUpdateDependiente(long socioId, AgregarDependienteEvent agregarDependienteEvent)
    {
        var dependienteSocio = agregarDependienteEvent.DependienteSocio;
        using var session = _store.OpenSession(TenantId);
        var socio = await session.LoadAsync<Socio>(socioId);
        if (socio == null) return BadRequest("Socio inválido");
        var dependiente = socio.Dependientes.FirstOrDefault(x => x.Id == dependienteSocio.Id);
        if (dependiente == null)
        {
            var refId = Guid.NewGuid();
            var newid = socio.Dependientes.Any() ? socio.Dependientes.Max(x => x.Id) + 1 : 1;
            dependiente = dependienteSocio with
            {
                Id = newid,
                MovimientoId = refId
            };
            socio.Dependientes.Add(dependiente);
            //
            var mov = new MovimientoSocio
            {
                SocioId = socio.Id,
                ReferenciaId = refId,
                TipoMovimiento = TipoMovimiento.AgregarDependiente,
                Estatus = EstatusMovimiento.Pendiente,
                FechaRegistro = DateTime.Today,
                RegistradaPor = agregarDependienteEvent.UserName,
                Nota =
                    $"El socio {socio.NumeroCarnet} - {socio.Nombre}, desea agregar a {dependiente.Nombre} como un dependiente a su membresía."
            };
            //
            session.Store( mov );
        }
        else
        {
            socio.Dependientes.Remove(dependiente);
            socio.Dependientes.Add(dependienteSocio);
        }
        session.Store(socio);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost("dependiente/activar", Name = "ReactivarDependienteDeSocio")]
    public async Task<ActionResult<Socio>> ReactivateDependiente(AgregarDependienteEvent agregarDependienteEvent)
    {
        using var session = _store.OpenSession(TenantId);
        var socio = await session.LoadAsync<Socio>(agregarDependienteEvent.SocioId);
        if (socio == null) return BadRequest("Socio inválido");
        var dependiente = socio.Dependientes.FirstOrDefault(x => x.Id == agregarDependienteEvent.DependienteSocio.Id);
        if (dependiente == null || dependiente.Estatus != EstatusMovimiento.Rechazado)
        {
            return BadRequest("Adicional inválido");
        }

        var refId = Guid.NewGuid();
        var mov = new MovimientoSocio
        {
            SocioId = socio.Id,
            ReferenciaId = refId,
            TipoMovimiento = TipoMovimiento.AgregarDependiente,
            Estatus = EstatusMovimiento.Pendiente,
            FechaRegistro = DateTime.Today,
            RegistradaPor = agregarDependienteEvent.UserName,
            Nota =
                $"El socio {socio.NumeroCarnet} - {socio.Nombre}, desea activar a {dependiente.Nombre} como un dependiente a su membresía."
        };
        dependiente.MovimientoId = refId;
        dependiente.Estatus = EstatusMovimiento.Pendiente;
        session.Store(socio);
        session.Store(mov);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost("dependiente/cancelar", Name = "RemoveDependienteDeSocio")]
    public async Task<ActionResult<Socio>> RemoveDependiente(AgregarDependienteEvent agregarDependienteEvent)
    {
        using var session = _store.OpenSession(TenantId);
        var socio = await session.LoadAsync<Socio>(agregarDependienteEvent.SocioId);
        if (socio == null) return BadRequest("Socio inválido");
        var dependiente = socio.Dependientes.FirstOrDefault(x => x.Id == agregarDependienteEvent.DependienteSocio.Id);
        if (dependiente == null || dependiente.Estatus != EstatusMovimiento.Aprobado)
        {
            return BadRequest("Adicional inválido");
        }

        var refId = Guid.NewGuid();
        var mov = new MovimientoSocio
        {
            SocioId = socio.Id,
            ReferenciaId = refId,
            TipoMovimiento = TipoMovimiento.QuitarDependiente,
            Estatus = EstatusMovimiento.Pendiente,
            FechaRegistro = DateTime.Today,
            RegistradaPor = agregarDependienteEvent.UserName,
            Nota =
                $"El socio {socio.NumeroCarnet} - {socio.Nombre}, desea retirar a {dependiente.Nombre} como un dependiente a su membresía."
        };
        dependiente.MovimientoId = refId;
        session.Store(mov);
        session.Store(socio);
        await session.SaveChangesAsync();
        return Ok();
    }

    #endregion
    
    #region Huespedes

    [HttpPost("huesped/{socioId:long}", Name = "AddOrUpdateHuespedDeSocio")]
    public async Task<ActionResult<Socio>> AddOrUpdateHuesped(long socioId, AgregarHuespedEvent agregarHuespedEvent)
    {
        var huespedSocio = agregarHuespedEvent.HuespedSocio;
        using var session = _store.OpenSession(TenantId);
        var socio = await session.LoadAsync<Socio>(socioId);
        if (socio == null) return BadRequest("Socio inválido");
        var huesped = socio.Huespededes.FirstOrDefault(x => x.Id == huespedSocio.Id);
        if (huesped == null)
        {
            var refId = Guid.NewGuid();
            var newid = socio.Huespededes.Any() ? socio.Dependientes.Max(x => x.Id) + 1 : 1;
            huesped = huespedSocio with
            {
                Id = newid,
                MovimientoId = refId
            };
            socio.Huespededes.Add(huesped);
            //
            var mov = new MovimientoSocio
            {
                SocioId = socio.Id,
                ReferenciaId = refId,
                TipoMovimiento = TipoMovimiento.SolicitarHuesped,
                Estatus = EstatusMovimiento.Pendiente,
                FechaRegistro = DateTime.Today,
                RegistradaPor = agregarHuespedEvent.UserName,
                Nota =
                    $"El socio {socio.NumeroCarnet} - {socio.Nombre}, desea agregar a {huesped.Nombre} como un huesped a su membresía."
            };
            //
            session.Store( mov );
        }
        else
        {
            socio.Huespededes.Remove(huesped);
            socio.Huespededes.Add(huespedSocio);
        }
        session.Store(socio);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost("huesped/activar", Name = "ReactivarHuespedDeSocio")]
    public async Task<ActionResult<Socio>> ReactivateHuesped(AgregarHuespedEvent agregarHuespedEvent)
    {
        using var session = _store.OpenSession(TenantId);
        var socio = await session.LoadAsync<Socio>(agregarHuespedEvent.SocioId);
        if (socio == null) return BadRequest("Socio inválido");
        var huesped = socio.Huespededes.FirstOrDefault(x => x.Id == agregarHuespedEvent.HuespedSocio.Id);
        if (huesped == null || huesped.Estatus != EstatusMovimiento.Rechazado)
        {
            return BadRequest("Adicional inválido");
        }

        var refId = Guid.NewGuid();
        var mov = new MovimientoSocio
        {
            SocioId = socio.Id,
            ReferenciaId = refId,
            TipoMovimiento = TipoMovimiento.SolicitarHuesped,
            Estatus = EstatusMovimiento.Pendiente,
            FechaRegistro = DateTime.Today,
            RegistradaPor = agregarHuespedEvent.UserName,
            Nota =
                $"El socio {socio.NumeroCarnet} - {socio.Nombre}, desea activar a {huesped.Nombre} como un huesped a su membresía."
        };
        huesped.MovimientoId = refId;
        huesped.Estatus = EstatusMovimiento.Pendiente;
        session.Store(socio);
        session.Store(mov);
        await session.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost("huesped/cancelar", Name = "RemoveHuespedDeSocio")]
    public async Task<ActionResult<Socio>> RemoveHuesped(AgregarHuespedEvent agregarHuespedEvent)
    {
        using var session = _store.OpenSession(TenantId);
        var socio = await session.LoadAsync<Socio>(agregarHuespedEvent.SocioId);
        if (socio == null) return BadRequest("Socio inválido");
        var huesped = socio.Huespededes.FirstOrDefault(x => x.Id == agregarHuespedEvent.HuespedSocio.Id);
        if (huesped == null || huesped.Estatus != EstatusMovimiento.Aprobado)
        {
            return BadRequest("Adicional inválido");
        }

        var refId = Guid.NewGuid();
        var mov = new MovimientoSocio
        {
            SocioId = socio.Id,
            ReferenciaId = refId,
            TipoMovimiento = TipoMovimiento.QuitarHuesped,
            Estatus = EstatusMovimiento.Pendiente,
            FechaRegistro = DateTime.Today,
            RegistradaPor = agregarHuespedEvent.UserName,
            Nota =
                $"El socio {socio.NumeroCarnet} - {socio.Nombre}, desea retirar a {huesped.Nombre} como un huesped a su membresía."
        };
        huesped.MovimientoId = refId;
        session.Store(mov);
        session.Store(socio);
        await session.SaveChangesAsync();
        return Ok();
    }

    #endregion
    
    
    [HttpPost("embarcacion/{socioId:long}", Name = "AddOrUpdateEmbarcacion")]
    public async Task<ActionResult<Socio>> AddOrUpdateEmbaracion(long socioId, Embarcacion embarcacionSocio)
    {
        using var session = _store.OpenSession(TenantId);
        var socio = await session.LoadAsync<Socio>(socioId);
        if (socio == null) return BadRequest("Socio inválido");
        var embarcacion = socio.Embarcaciones.FirstOrDefault(x => x.Nombre == embarcacionSocio.Nombre);
        if (embarcacion != null)
        {
            socio.Embarcaciones.Remove(embarcacion);
        }
        socio.Embarcaciones.Add(embarcacionSocio);
        session.Store(socio);
        await session.SaveChangesAsync();
        return Ok();
    }
    [HttpPost("embarcacion/remove/{socioId:long}", Name = "RemoveEmbarcacion")]
    public async Task<ActionResult<Socio>> RemoveEmbaracion(long socioId, Embarcacion embarcacionSocio)
    {
        using var session = _store.OpenSession(TenantId);
        var socio = await session.LoadAsync<Socio>(socioId);
        if (socio == null) return BadRequest("Socio inválido");
        var embarcacion = socio.Embarcaciones.FirstOrDefault(x => x.Nombre == embarcacionSocio.Nombre);
        if (embarcacion == null)
        {
            return NotFound();
        }
        socio.Embarcaciones.Remove(embarcacion);
        session.Store(socio);
        await session.SaveChangesAsync();
        return Ok();
    }
}