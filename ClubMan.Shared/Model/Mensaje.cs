namespace ClubMan.Shared.Model;

public record Mensaje()
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Titulo { get; set; }
    public string Contenido { get; set; }
    public string DetalleUrl { get; set; }
    public DateTime FechaHora { get; set; } = DateTime.Today;
    public bool Enviado { get; set; } = false;
}