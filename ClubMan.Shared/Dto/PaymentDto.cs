namespace ClubMan.Shared.Dto;

public class PaymentDto
{
    public long SocioId { get; set; }
    public string Carnet { get; set; }
    public DateTime Fecha { get; set; }
    public Decimal TotalPago { get; set; }
    public List<PaymentDocumentsDto> Documents { get; set; } = new();
}

public class PaymentDocumentsDto
{
    public string IdDocumento { get; set; }
    public string Documento { get; set; }
    public Decimal Pagado { get; set; }
}