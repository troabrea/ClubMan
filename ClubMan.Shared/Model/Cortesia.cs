namespace ClubMan.Shared.Model;

public record Cortesia
{
    public long Id { get; set; }
    public String NumeroCarnet { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaExpiracion { get; set; }
    public String Nombre { get; set; }
    public String NumeroIdentidad { get; set; }
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
}