namespace ClubMan.Shared.Model;

public class Carnet
{
    public string CarnetId { get; set; }
    public TipoCarnet Tipo { get; set; }
    public EstatusCarnet Estatus { get; set; }
    public string NumeroIdentidad { get; set; }
    public string Nombre { get; set; }
    public string FotoUrl { get; set; }
    public long SocioId { get; set; }
    public long ReferenciaId { get; set; } 
    public DateTime Desde { get; set; }
    public int DiasValidez { get; set; }
}