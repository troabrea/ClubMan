namespace ClubMan.Shared.Model;

public record EventoDeSocio
{
    public Guid MovimientoId { get; set; } = Guid.NewGuid();
    public long Id { get; set; }
    public long SocioId { get; set; }
    public DateTime FechaHora { get; set; } = DateTime.Now;
    public int Horas { get; set; } = 4;
    public Guid InstalacionId { get; set; }
    public String Descripcion { get; set; }
    public int Personas { get; set; }
    public EstatusEvento Estatus { get; set; }
    public List<InvitadoEvento> Invitados { get; set; } = new();
}

public record InvitadoEvento
{
    public string NumeroIdentidad { get; set; }
    public string Nombre { get; set; }
}
