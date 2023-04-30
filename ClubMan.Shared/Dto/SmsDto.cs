namespace ClubMan.Shared.Dto;

public class SmsDto
{
    public string Celular { get; set; }
    public string Mensaje { get; set; }
    public string Referencia { get; set; }
}

public class SmsRequestDto
{
    public string ClientKey { get; set; }
    public string ClientId { get; set; }
    public string Celular { get; set; }
    public string Mensaje { get; set; }
    public string Referencia { get; set; }
}
