using System.Diagnostics;
using System.Xml;
using ClubMan.Shared.Events;
using ClubMan.Shared.Helpers;

namespace ClubMan.Shared.Model;

public record Socio
{
    public long Id { get; set; }
    public EstatusMembresia EstatusMembresia { get; set; }
    public long SolicitudId { get; set; }
    public String NumeroCarnet { get; set; }
    public TipoSocio TipoSocio { get; set; }
    public DateTime FechaMembresia { get; set; }
    public String Nombre { get; set; }
    public String Empresa { get; set; }
    public String NumeroIdentidad { get; set; }
    public String NumeroFiscal { get; set; }
    public EstadoCivil EstadoCivil { get; set; }
    public Sexo Sexo { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public String Nacionalidad { get; set; }
    public String Direccion { get; set; }
    public String Sector { get; set; }
    public String Ciudad { get; set; }
    public String Pais { get; set; }
    public String TelefonoResidencia { get; set; }
    public String Celular { get; set; }
    public String Email { get; set; }
    public String LugarTrabajo { get; set; }
    public String Posicion { get; set; }
    public String DireccionTrabajo { get; set; }
    public String TelefonoOficina { get; set; }
    public String TelefonoFlota { get; set; }
    public String Fax { get; set; }
    public String EmailTrabajo { get; set; }
    public String NombreAsistente { get; set; }
    public String EmailAsitente { get; set; }
    public String FotoUrl { get; set; }
    public List<DependienteSocio> Dependientes { get; set; } = new();
    public List<Embarcacion> Embarcaciones { get; set; } = new();
    public List<AdicionalSocio> Adicionales { get; set; } = new();
    public int Edad => FechaNacimiento.Age();
    public string TipoDeSocio => TipoSocio.ToString();
    
    public static Socio FromSolicitud(Solicitud sol, AprobarSolicitudEvent approval)
    {
        var socio = new Socio()
        {
            SolicitudId = sol.Id,
            EstatusMembresia = EstatusMembresia.Activa,
            NumeroCarnet = approval.NumeroAprobacion,
            FechaMembresia = DateTime.Today,
            FotoUrl = sol.FotoSocioUrl,
            TipoSocio = sol.TipoSocio,
            Empresa = String.IsNullOrEmpty(sol.Beneficiario) ? string.Empty  : sol.Solicitante,
            Nombre = sol.SolicitudPara,
            NumeroIdentidad = sol.NumeroIdentidad,
            NumeroFiscal = sol.NumeroFiscal,
            FechaNacimiento = sol.FechaNacimiento,
            EstadoCivil = sol.EstadoCivil,
            Sexo = sol.Sexo,
            Nacionalidad = sol.Nacionalidad,
            Direccion = sol.Direccion,
            Sector = sol.Sector,
            Ciudad = sol.Ciudad,
            Pais = sol.Pais,
            TelefonoResidencia = sol.TelefonoResidencia,
            TelefonoOficina = sol.TelefonoOficina,
            TelefonoFlota = sol.TelefonoFlota,
            Celular = sol.Celular,
            Email = sol.Email,
            LugarTrabajo = sol.LugarTrabajo,
            DireccionTrabajo = sol.DireccionTrabajo,
            Posicion = sol.Posición,
            Fax = sol.Fax,
            EmailTrabajo = sol.EmailTrabajo,
            NombreAsistente = sol.NombreAsistente,
            EmailAsitente = sol.EmailAsitente
        };
        int iDep = 0;
        foreach (var dep in sol.Dependientes.OrderBy(x => x.FechaNacimiento))
        {
            iDep++;
            socio.Dependientes.Add(new DependienteSocio()
            {
                Id=iDep,
                NumeroCarnet = $"{socio.NumeroCarnet}-{iDep.ToString()}",
                Celular = dep.Celular,
                Email = dep.Email,
                Nacionalidad = dep.Nacionalidad,
                Nombre = dep.Nombre,
                Posicion = dep.Posicion,
                Sexo = dep.Sexo,
                DireccionTrabajo = dep.DireccionTrabajo,
                FechaNacimiento = dep.FechaNacimiento,
                FotoUrl = dep.FotoUrl,
                LugarTrabajo = dep.LugarTrabajo,
                NumeroIndentidad = dep.NumeroIndentidad,
                TelefonoTrabajo = dep.TelefonoTrabajo,
                TipoDependiente = dep.TipoDependiente,
                Estatus = EstatusMovimiento.Aprobado
            });
        }

        foreach (var emb in sol.Embarcaciones)
        {
            socio.Embarcaciones.Add( emb with {} );
        }
        
        return socio;
    }
    
}
public record DependienteSocio
{
    public long Id { get; set; }
    public String NumeroCarnet { get; set; }
    public TipoDependiente TipoDependiente { get; set; }
    public String Nombre { get; set; }
    public String NumeroIndentidad { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public String Nacionalidad { get; set; }
    public Sexo Sexo { get; set; }
    public String Celular { get; set; }
    public String Email { get; set; }
    
    public String LugarTrabajo { get; set; }
    public String Posicion { get; set; }
    public String DireccionTrabajo { get; set; }
    public String TelefonoTrabajo { get; set; }
    
    public String FotoUrl { get; set; }

    public int Edad => FechaNacimiento.Age();
    public EstatusMovimiento Estatus { get; set; }
    public Guid MovimientoId { get; set; }
}

public record AdicionalSocio
{
    public long Id { get; set; }
    public TipoAdicional TipoAdicional { get; set; }
    public String Descripcion { get; set; }
    public String Nombre { get; set; }
    public String NumeroIdentidad { get; set; }
    public String Observaciones { get; set; }
    public String FotoUrl { get; set; }
    public EstatusMovimiento Estatus { get; set; }
    public Guid MovimientoId { get; set; }
}

public record MovimientoSocio
{
    public long Id { get; set; }
    public long SocioId { get; set; }
    public long DependienteId { get; set; }
    public TipoMovimiento TipoMovimiento { get; set; }
    public Guid ReferenciaId { get; set; }
    public String Nota { get; set; }
    public DateTime FechaRegistro { get; set; }
    public String RegistradaPor { get; set; }
    public DateTime FechaRevision { get; set; }
    public String RevisadoPor { get; set; }
    public String Comentario { get; set; }
    public EstatusMovimiento Estatus { get; set; }

    public string TipoDeMovimiento =>
        TipoMovimiento switch
        {
            TipoMovimiento.AgregarAdicional => "Agregar Adicional",
            TipoMovimiento.CambiarAPasiva => "Cambiar a Pasiva",
            TipoMovimiento.ReActivar => "Reactivar Membresía",
            TipoMovimiento.BloquearEntrada => "Bloquear Entrada",
            TipoMovimiento.MarcarComoNoResidente => "Marcar No-Residente",
            TipoMovimiento.CancelarMembresia => "Cancelar Membresia",
            TipoMovimiento.AgregarDependiente => "Agregar Dependiente",
            TipoMovimiento.QuitarDependiente => "Remover Dependiente",
            TipoMovimiento.QuitarAdicional => "Remover Adicional",
            TipoMovimiento.SolicitarHuesped => "Activar Huesped(es)",
            TipoMovimiento.SolicitarActividad => "Aprobar Evento",
            TipoMovimiento.SolicitarInvitadoExtraordinario => "Aprobar invitado extraordinario",
            _ => ""
        };
}