namespace ClubMan.Shared.Model;

public record Localidad()
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public String Nombre { get; set; }
    public String Direccion { get; set; }
    public double Latitud { get; set; }
    public double Longitud { get; set; }
    public int Orden { get; set; }
    public bool SoloOficina { get; set; } = false;
    public bool Publicado { get; set; } = true;
}