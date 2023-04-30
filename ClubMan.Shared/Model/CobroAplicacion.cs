namespace ClubMan.Shared.Model;

public class CobroAplicacion
{
    public long Id { get; set; }
    public long CobroId { get; set; }
    public string IdDocumento { get; set; }
    public string Documento { get; set; }
    public Decimal Pagado { get; set; }
}