namespace ClubMan.Shared.Dto;

public record FacturaDto()
{
    public string ErpId { get; set; }
    public long SocioId { get; set; }
    public string NumeroFactura { get; set; }
    public DateTime FechaFactura { get; set; }
    public string Concepto { get; set; }
    public decimal Total { get; set; }
    public decimal Pagado { get; set; }
    public decimal Balance { get; set; }
}