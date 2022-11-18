using System.Globalization;
using ClubMan.Shared.Helpers;

namespace ClubMan.Shared.Model;

public record MembresiaAlterna
{
    public String NombreClub { get; set; }
    public DateTime MiembroDesde { get; set; }
}

public record Dependiente
{
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

    public int Edad => FechaNacimiento.Age();
}

public record SocioSecundador
{
    public String NumeroSocio { get; set; }
    public String NombreSocio { get; set; }
}

public record ReferenciaBancaria
{
    public String Banco { get; set; }
    public String OficialCuenta { get; set; }
    public String NumeroDeCuenta { get; set; }
}

public record Embarcacion
{
    public String Nombre { get; set; }
    public String Tipo { get; set; }
    public String Marca { get; set; }
    public double Eslora { get; set; }
    public double Manga { get; set; }
    public String Localizacion { get; set; }
}

public record Revision
{
    public DateTime FechaSometida { get; set; }
    public EstatusRevision EstatusRevision { get; set; }
    public String NumeroAprobacion { get; set; }
    public DateTime FechaRevision { get; set; }
    public String Observaciones { get; set; }
    public int CantidadAcciones { get; set; }
    public decimal Valoracciones { get; set; }
    public String SometidaPor { get; set; }
    public String CompletadaPor { get; set; }
}

public record Solicitud
{
    public long Id { get; set; }
    public EstatusSolicitud EstatusSolicitud { get; set; }
    public TipoSocio TipoSocio { get; set; }
    public DateTime FechaSolicitud { get; set; }
    
    public DateTime? UltimoSometimiento { get; set; }
    public DateTime? UltimaRevision { get; set; }
    public String Solicitante { get; set; }
    public String Beneficiario { get; set; }
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
    public String Posición { get; set; }
    public String DireccionTrabajo { get; set; }
    public String TelefonoOficina { get; set; }
    public String TelefonoFlota { get; set; }
    public String Fax { get; set; }
    public String EmailTrabajo { get; set; }
    public String NombreAsistente { get; set; }
    public String EmailAsitente { get; set; }
    public List<MembresiaAlterna> MembresiasAlternas { get; set; }
    public List<Dependiente> Dependientes { get; set; }
    public List<SocioSecundador> SociosSecundadores { get; set; }
    public List<ReferenciaBancaria> ReferenciasBancarias { get; set; }
    public List<Embarcacion> Emabarcaciones { get; set; }
    
    public List<Revision> Revisiones { get; set; }

    public String SolicitudPara => String.IsNullOrEmpty(Beneficiario) ? Solicitante : $"{Solicitante} / {Beneficiario}";

    public int Edad => FechaNacimiento.Age();
    
    public static Solicitud FromPdfForm(SolicitudPdfForm dto)
    {
        var sol = new Solicitud
        {
            EstatusSolicitud = EstatusSolicitud.Recibida,
            FechaSolicitud = DateTime.ParseExact(dto.ddmmaaaa, "dd-MM-yyyy",CultureInfo.InvariantCulture),
            //
            TipoSocio = TipoSocio.Numeral
        };
        if (dto.Corporativo == "On") sol.TipoSocio = TipoSocio.Corporativo;
        if (dto.Propietario == "On") sol.TipoSocio = TipoSocio.Propietario;
        if (dto.Diplomatico == "On") sol.TipoSocio = TipoSocio.Diplomatico;
        if (dto.Especial == "On") sol.TipoSocio = TipoSocio.Especial;
        //
        DatosDeMemberia(dto, sol);
        MembresiasAdicionales(dto, sol);
        DatosDependientes(dto, sol);
        DatosSociosSecundadores(dto, sol);
        DatosReferenciasBancarias(dto, sol);
        DatosDeEmbarcacion(dto, sol);
        return sol;
    }

    private static void DatosDeEmbarcacion(SolicitudPdfForm dto, Solicitud sol)
    {
        sol.Emabarcaciones = new List<Embarcacion>();
        if (!String.IsNullOrEmpty(dto.undefined_2))
        {
            sol.Emabarcaciones.Add(new Embarcacion()
            {
                Nombre = dto.undefined_2,
                Eslora = double.Parse( dto.pies ),
                Manga = double.Parse(dto.Manga),
                Marca = dto.Marca,
                Tipo = dto.Tipo,
                Localizacion = dto.Actualmentelocalizadoen
            });
        }
    }
    private static void DatosReferenciasBancarias(SolicitudPdfForm dto, Solicitud sol)
    {
        sol.ReferenciasBancarias = new();
        if (!string.IsNullOrEmpty(dto.undefined))
        {
            sol.ReferenciasBancarias.Add(new ReferenciaBancaria()
            {
                Banco = dto.undefined,
                NumeroDeCuenta = dto.Cuenta,
                OficialCuenta = dto.OficialdeCuenta
            });
        }
        if (!string.IsNullOrEmpty(dto.DETENEREMBARCACIONES))
        {
            sol.ReferenciasBancarias.Add(new ReferenciaBancaria()
            {
                Banco = dto.DETENEREMBARCACIONES,
                NumeroDeCuenta = dto.Cuenta_2,
                OficialCuenta = dto.OficialdeCuenta_2
            });
        }
    }
    
    private static void DatosSociosSecundadores(SolicitudPdfForm dto, Solicitud sol)
    {
        sol.SociosSecundadores = new();
        if (!String.IsNullOrEmpty(dto._1))
        {
            sol.SociosSecundadores.Add(new SocioSecundador()
            {
                NombreSocio = dto._1,
                NumeroSocio = dto.SocioNo
            });
        }
        if (!String.IsNullOrEmpty(dto._2))
        {
            sol.SociosSecundadores.Add(new SocioSecundador()
            {
                NombreSocio = dto._2,
                NumeroSocio = dto.SocioNo_2
            });
        }
        if (!String.IsNullOrEmpty(dto._3))
        {
            sol.SociosSecundadores.Add(new SocioSecundador()
            {
                NombreSocio = dto._3,
                NumeroSocio = dto.SocioNo_3
            });
        }
    }
    
    private static void DatosDependientes(SolicitudPdfForm dto, Solicitud sol)
    {
        sol.Dependientes = new();
        if (!string.IsNullOrEmpty(dto.NombredeEsposao))
        {
            sol.Dependientes.Add( new Dependiente()
            {
                TipoDependiente = TipoDependiente.Conyuge,
                Nombre = dto.NombredeEsposao,
                NumeroIndentidad = dto.Pasaporte_2,
                FechaNacimiento = DateTime.ParseExact(dto.FechaNacimiento_2,"dd-MM-yyyy",CultureInfo.InvariantCulture),
                Nacionalidad = dto.Nacionalidad_2,
                Sexo = dto.Femenino_2 == "On" ? Model.Sexo.Femenino : Sexo.Masculino,
                Celular = dto.Celular_2,
                Email = dto.Email_4,
                LugarTrabajo = dto.LugardeTrabajo_2,
                Posicion = dto.Posicin_2,
                DireccionTrabajo = dto.DireccindelLugardeTrabajo_2,
                TelefonoTrabajo = dto.Telefono
            });
        }
        if (!string.IsNullOrEmpty(dto.NombredeHijoa))
        {
            sol.Dependientes.Add( new Dependiente()
            {
                TipoDependiente = TipoDependiente.Hijo,
                Nombre = dto.NombredeHijoa,
                NumeroIndentidad = dto.Pasaporte_3,
                FechaNacimiento = DateTime.ParseExact(dto.FechaNacimiento_3,"dd-MM-yyyy",CultureInfo.InvariantCulture),
                Nacionalidad = dto.Nacionalidad_3,
                Sexo = dto.Femenino_3 == "On" ? Model.Sexo.Femenino : Sexo.Masculino,
                Celular = dto.Celular_3,
                Email = dto.Email_5,
            });
        }
        if (!string.IsNullOrEmpty(dto.NombredeHijoa_2))
        {
            sol.Dependientes.Add( new Dependiente()
            {
                TipoDependiente = TipoDependiente.Hijo,
                Nombre = dto.NombredeHijoa_2,
                NumeroIndentidad = dto.Pasaporte_4,
                FechaNacimiento = DateTime.ParseExact(dto.FechaNacimiento_4,"dd-MM-yyyy",CultureInfo.InvariantCulture),
                Nacionalidad = dto.Nacionalidad_4,
                Sexo = dto.Femenino_4 == "On" ? Model.Sexo.Femenino : Sexo.Masculino,
                Celular = dto.Celular_4,
                Email = dto.Email_6,
            });
        }
        if (!string.IsNullOrEmpty(dto.NombredeHijoa_3))
        {
            sol.Dependientes.Add( new Dependiente()
            {
                TipoDependiente = TipoDependiente.Hijo,
                Nombre = dto.NombredeHijoa_3,
                NumeroIndentidad = dto.Pasaporte_5,
                FechaNacimiento = DateTime.ParseExact(dto.FechaNacimiento_5,"dd-MM-yyyy",CultureInfo.InvariantCulture),
                Nacionalidad = dto.Nacionalidad_5,
                Sexo = dto.Femenino_5 == "On" ? Model.Sexo.Femenino : Sexo.Masculino,
                Celular = dto.Celular_5,
                Email = dto.Email_7,
            });
        }
        if (!string.IsNullOrEmpty(dto.NombredeHijoa_4))
        {
            sol.Dependientes.Add( new Dependiente()
            {
                TipoDependiente = TipoDependiente.Hijo,
                Nombre = dto.NombredeHijoa_4,
                NumeroIndentidad = dto.Pasaporte_6,
                FechaNacimiento = DateTime.ParseExact(dto.FechaNacimiento_6,"dd-MM-yyyy",CultureInfo.InvariantCulture),
                Nacionalidad = dto.Nacionalidad_6,
                Sexo = dto.Femenino_6 == "On" ? Model.Sexo.Femenino : Sexo.Masculino,
                Celular = dto.Celular_6,
                Email = dto.Email_8,
            });
        }
    }
    
    private static void MembresiasAdicionales(SolicitudPdfForm dto, Solicitud sol)
    {
        sol.MembresiasAlternas = new();
        if (!string.IsNullOrEmpty(dto.Nombre))
        {
            sol.MembresiasAlternas.Add( new MembresiaAlterna()
            {
                NombreClub = dto.Nombre,
                MiembroDesde = DateTime.ParseExact(dto.Desde, "dd-MM-yyyy",CultureInfo.InvariantCulture)
            });
        }
        if (!string.IsNullOrEmpty(dto.Nombre_2))
        {
            sol.MembresiasAlternas.Add( new MembresiaAlterna()
            {
                NombreClub = dto.Nombre_2,
                MiembroDesde = DateTime.ParseExact(dto.Desde_2, "dd-MM-yyyy",CultureInfo.InvariantCulture)
            });
        }
    }
    private static void DatosDeMemberia(SolicitudPdfForm dto, Solicitud sol)
    {
        sol.Solicitante = dto.NombredelaPersonaoInstitucinsolicitante;
        sol.Beneficiario = dto.NombredelEjecutivooBeneficiariodelaMembresa;
        sol.NumeroIdentidad = dto.Pasaporte;
        sol.NumeroFiscal = dto.RNC;
        sol.EstadoCivil = EstadoCivil.Casado;
        if (dto.Solteroa == "On") sol.EstadoCivil = EstadoCivil.Soltero;
        sol.Sexo = Sexo.Masculino;
        if (dto.Femenino == "On") sol.Sexo = Sexo.Femenino;
        sol.FechaNacimiento = DateTime.ParseExact(dto.FechaNacimiento, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        sol.Nacionalidad = dto.Nacionalidad;
        sol.Direccion = dto.Direccin;
        sol.Sector = dto.Sector;
        sol.Ciudad = dto.Ciudad;
        sol.Pais = dto.Pas;
        sol.TelefonoResidencia = dto.TelfonoResidencia;
        sol.Celular = dto.Celular;
        sol.Email = dto.Email;
        sol.LugarTrabajo = dto.LugardeTrabajo;
        sol.Posición = dto.Posicin;
        sol.TelefonoOficina = dto.TelfonoOficina;
        sol.EmailTrabajo = dto.Email_2;
        sol.NombreAsistente = dto.NombredeAsistente;
        sol.EmailAsitente = dto.Email_3;
    }
}