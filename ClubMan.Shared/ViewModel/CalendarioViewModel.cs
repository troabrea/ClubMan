namespace ClubMan.Shared.ViewModel;

public record CalendarioViewModel
{
    public int OwnerId {get;set;}
    public string ReferenciaId { get; set; }
    public string Titulo { get; set; }
    public string Lugar { get; set; }
    public string Nota { get; set; }
    public DateTime HoraInicio { get; set; }
    public DateTime HoraFin { get; set; }
}

public class CalendarioResourceData
{
    public int Id { get; set; }
    public string OwnerText { get; set; }
    public string OwnerColor { get; set; }
}