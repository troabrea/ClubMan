namespace ClubMan.Shared.Model;

public record Servicio
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string Categoria { get; set; }
    public string Horario { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public int Orden { get; set; }
    public bool Publicado { get; set; }
}