namespace ClubMan.Shared.Model;


public record Pregunta
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string Resumen { get; set; }
    public string Url { get; set; }
    public double Orden { get; set; }
    public bool Publicado { get; set; }
}