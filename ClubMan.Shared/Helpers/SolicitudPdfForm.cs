using System.Text.Json.Serialization;

namespace ClubMan.Shared.Helpers;

public class SolicitudPdfForm
{
    public string Propietario { get; set; }
        public string Numeral { get; set; }
        public string Corporativo { get; set; }
        public string Diplomatico { get; set; }
        public string Especial { get; set; }
        public string ddmmaaaa { get; set; }

        [JsonPropertyName("Nombre de la Persona o Institución solicitante")]
        public string NombredelaPersonaoInstitucinsolicitante { get; set; }

        [JsonPropertyName("Nombre del Ejecutivo o Beneficiario de la Membresía")]
        public string NombredelEjecutivooBeneficiariodelaMembresa { get; set; }
        public string Pasaporte { get; set; }
        public string Solteroa { get; set; }
        public string Casadoa { get; set; }
        public string Masculino { get; set; }
        public string Femenino { get; set; }
        public string RNC { get; set; }

        [JsonPropertyName("Fecha Nacimiento")]
        public string FechaNacimiento { get; set; }
        public string Edad { get; set; }
        public string Nacionalidad { get; set; }
        public string Direccin { get; set; }
        public string Sector { get; set; }
        public string Ciudad { get; set; }
        public string Pas { get; set; }

        [JsonPropertyName("Teléfono Residencia")]
        public string TelfonoResidencia { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }

        [JsonPropertyName("Lugar de Trabajo")]
        public string LugardeTrabajo { get; set; }
        public string Posicin { get; set; }

        [JsonPropertyName("Dirección del Lugar de Trabajo")]
        public string DireccindelLugardeTrabajo { get; set; }
        public string Fax { get; set; }

        [JsonPropertyName("Teléfono Oficina")]
        public string TelfonoOficina { get; set; }
        public string Flota { get; set; }
        public string Email_2 { get; set; }

        [JsonPropertyName("Nombre de Asistente")]
        public string NombredeAsistente { get; set; }
        public string Email_3 { get; set; }
        public string Nombre { get; set; }
        public string Desde { get; set; }
        public string Nombre_2 { get; set; }
        public string Desde_2 { get; set; }

        [JsonPropertyName("Nombre de Esposao")]
        public string NombredeEsposao { get; set; }
        public string Pasaporte_2 { get; set; }

        [JsonPropertyName("Fecha Nacimiento_2")]
        public string FechaNacimiento_2 { get; set; }
        public string Edad_2 { get; set; }
        public string Nacionalidad_2 { get; set; }
        public string Masculino_2 { get; set; }
        public string Femenino_2 { get; set; }
        public string Celular_2 { get; set; }
        public string Email_4 { get; set; }

        [JsonPropertyName("Lugar de Trabajo_2")]
        public string LugardeTrabajo_2 { get; set; }
        public string Posicin_2 { get; set; }

        [JsonPropertyName("Dirección del Lugar de Trabajo_2")]
        public string DireccindelLugardeTrabajo_2 { get; set; }
        public string Telefono { get; set; }

        [JsonPropertyName("Nombre de Hijoa")]
        public string NombredeHijoa { get; set; }
        public string Pasaporte_3 { get; set; }

        [JsonPropertyName("Fecha Nacimiento_3")]
        public string FechaNacimiento_3 { get; set; }
        public string Edad_3 { get; set; }
        public string Nacionalidad_3 { get; set; }
        public string Masculino_3 { get; set; }
        public string Femenino_3 { get; set; }
        public string Celular_3 { get; set; }
        public string Email_5 { get; set; }

        [JsonPropertyName("Nombre de Hijoa_2")]
        public string NombredeHijoa_2 { get; set; }
        public string Pasaporte_4 { get; set; }

        [JsonPropertyName("Fecha Nacimiento_4")]
        public string FechaNacimiento_4 { get; set; }
        public string Edad_4 { get; set; }
        public string Nacionalidad_4 { get; set; }
        public string Masculino_4 { get; set; }
        public string Femenino_4 { get; set; }
        public string Celular_4 { get; set; }
        public string Email_6 { get; set; }

        [JsonPropertyName("Nombre de Hijoa_3")]
        public string NombredeHijoa_3 { get; set; }
        public string Pasaporte_5 { get; set; }

        [JsonPropertyName("Fecha Nacimiento_5")]
        public string FechaNacimiento_5 { get; set; }
        public string Edad_5 { get; set; }
        public string Nacionalidad_5 { get; set; }
        public string Masculino_5 { get; set; }
        public string Femenino_5 { get; set; }
        public string Celular_5 { get; set; }
        public string Email_7 { get; set; }

        [JsonPropertyName("Nombre de Hijoa_4")]
        public string NombredeHijoa_4 { get; set; }
        public string Pasaporte_6 { get; set; }

        [JsonPropertyName("Fecha Nacimiento_6")]
        public string FechaNacimiento_6 { get; set; }
        public string Edad_6 { get; set; }
        public string Nacionalidad_6 { get; set; }
        public string Masculino_6 { get; set; }
        public string Femenino_6 { get; set; }
        public string Celular_6 { get; set; }
        public string Email_8 { get; set; }

        [JsonPropertyName("1")]
        public string _1 { get; set; }

        [JsonPropertyName("2")]
        public string _2 { get; set; }

        [JsonPropertyName("3")]
        public string _3 { get; set; }

        [JsonPropertyName("Socio No")]
        public string SocioNo { get; set; }

        [JsonPropertyName("Socio No_2")]
        public string SocioNo_2 { get; set; }

        [JsonPropertyName("Socio No_3")]
        public string SocioNo_3 { get; set; }
        public string undefined { get; set; }

        [JsonPropertyName("Oficial de Cuenta")]
        public string OficialdeCuenta { get; set; }
        public string Cuenta { get; set; }

        [JsonPropertyName("DE TENER EMBARCACIONES")]
        public string DETENEREMBARCACIONES { get; set; }

        [JsonPropertyName("Oficial de Cuenta_2")]
        public string OficialdeCuenta_2 { get; set; }
        public string Cuenta_2 { get; set; }
        public string undefined_2 { get; set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string pies { get; set; }
        public string Manga { get; set; }

        [JsonPropertyName("Actualmente localizado en")]
        public string Actualmentelocalizadoen { get; set; }
        public string undefined_3 { get; set; }
        public string APROBADO { get; set; }
        public string RECHAZADO { get; set; }
        public string POSPUESTO { get; set; }

        [JsonPropertyName("Conocido en reunión de la Junta Directiva de fecha")]
        public string ConocidoenreunindelaJuntaDirectivadefecha { get; set; }

        [JsonPropertyName("Aprobación No")]
        public string AprobacinNo { get; set; }

        [JsonPropertyName("Registro de Socio No")]
        public string RegistrodeSocioNo { get; set; }

        [JsonPropertyName("Si aplica Acciones s")]
        public string SiaplicaAccioness { get; set; }

        [JsonPropertyName("Valor por Acción RD")]
        public string ValorporAccinRD { get; set; }
        public string undefined_4 { get; set; }
        public string undefined_5 { get; set; }
        public string undefined_6 { get; set; }
        public string undefined_7 { get; set; }
        public string undefined_8 { get; set; }
        public string undefined_9 { get; set; }
        public string undefined_10 { get; set; }
        public string undefined_11 { get; set; }
        public string undefined_12 { get; set; }
        public string undefined_13 { get; set; }
        public string undefined_14 { get; set; }
}