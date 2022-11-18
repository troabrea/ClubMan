namespace ClubMan.Shared.Model;

public record Noticia()
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Titulo { get; set; }
    public string Resumen { get; set; }
    public string Contenido { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Today;
    public string ImagenUrl { get; set; }
    public string DetalleUrl { get; set; }
    public string Autor { get; set; }
    public bool Publicado { get; set; } = true;
}