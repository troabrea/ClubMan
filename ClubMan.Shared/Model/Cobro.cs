namespace ClubMan.Shared.Model;

public class Cobro
{
    public long Id { get; set; }
    public long SocioId { get; set; }
    public string Carnet { get; set; }
    public DateTime Fecha { get; set; }
    public Decimal TotalPago { get; set; }
    public short Estatus { get; set; }
    public string NumeroTarjeta { get; set; }
    public string NumeroConfirmacion { get; set; }
    public DateTime ConfirmadoEn { get; set; }
    public string Mensaje { get; set; }
    public string Concepto => "Pago membresía";
    public string TotalPagoStr => $"RD{TotalPago:C2}";
    public List<CobroAplicacion> Aplicaciones { get; set; } = new();
}