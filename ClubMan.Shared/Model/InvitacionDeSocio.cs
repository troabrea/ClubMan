namespace ClubMan.Shared.Model;

public record InvitacionDeSocio
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public EstatusInvitacion Estatus { get; set; }
    public long SocioId { get; set; }
    public String NumeroCarnet { get; set; }
    public DateTime FechaHora { get; set; } = DateTime.Now;
    public String NumeroIdentidad { get; set; }
    public String NombreCompleto { get; set; }
    public String Email { get; set; }
    public String WhatsApp { get; set; }
    public DateTime FechaHoraVisita { get; set; } = DateTime.Now;
}