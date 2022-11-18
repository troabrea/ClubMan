namespace ClubMan.Shared.Model;
public record Instalacion
{
    public Guid Id { get; set; }
    public Guid LocalidadId { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public int Capacidad { get; set; }
    public string ImagenUrl { get; set; }
    public bool Activo { get; set; }
    public bool Reservable { get; set; }
}
