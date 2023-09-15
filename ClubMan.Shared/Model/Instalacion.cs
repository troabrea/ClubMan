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
    public string MenuUrl { get; set; }
    public decimal CostoReserva { get; set; }
    public string Horario { get; set; }
    public bool Bloqueado { get; set; }
    public String BloqueadoRazon { get; set; }
    public DateTime BloqueadoDesde { get; set; }
    public DateTime BloqueadoHasta { get; set; }
}
