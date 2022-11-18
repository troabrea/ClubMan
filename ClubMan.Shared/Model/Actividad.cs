namespace ClubMan.Shared.Model;

public record Actividad()
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid InstalacionId { get; set; }
    public string Titulo { get; set; }
    public DateTime FechaHora { get; set; } = DateTime.Now;
    public int Horas { get; set; } = 4;
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string ImagenUrl { get; set; }
    public string DetalleUrl { get; set; }
    public bool Publicado { get; set; }
}