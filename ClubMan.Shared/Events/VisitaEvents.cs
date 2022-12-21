using ClubMan.Shared.Model;

namespace ClubMan.Shared.Events;

public record VisitaCarnetRegistradaEvent
{
    public String Id { get; set; }
    public DateTime FechaHora { get; set; }
    public TipoCarnet TipoCarnet { get; set; }
    public string CarnetId { get; set; }
    public long SocioId { get; set; }
    public Guid PorteroId { get; set; }
}
public record VisitaAdicionalSocioRegistradaEvent
{
    public String Id { get; set; }
    public String CarnetId { get; set; }
    public DateTime FechaHora { get; set; }
    public long SocioId { get; set; }
    public string NumeroIndentidad { get; set; }
}
public record VisitaInvitadoSocioRegistradaEvent
{
    public String Id { get; set; }
    public String CarnetId { get; set; }
    public DateTime FechaHora { get; set; }
    public long SocioId { get; set; }
}
public record VisitaSocioRegistradaEvent
{
    public String Id { get; set; }
    public DateTime FechaHora { get; set; }
    public TipoCarnet TipoCarnet { get; set; }
}
public record VisitaInvitadoRegistradaEvent
{
    public String Id { get; set; }
    public DateTime FechaHora { get; set; }
    public string NumeroIdentidad { get; set; }
    public string InvitadoDe { get; set; }
    public string CarnetId { get; set; }
    public long SocioId { get; set; }
}



