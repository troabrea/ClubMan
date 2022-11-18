namespace ClubMan.Shared.Model;

public record Empresa
{
    public Guid Id { get; set; }
    public String Nombre { get; set; }
    public String Direccion { get; set; }
    public String LogoUrl { get; set; }
    public String Email { get; set; }
    public String Telefono { get; set; }
    public String TelefonoAdicional { get; set; }
    public String WhatsApp { get; set; }
    public String SobreNosotros { get; set; }
    public String Vision { get; set; }
    public String Mision { get; set; }
    public String Facebook { get; set; }
    public String Instagram { get; set; }
    public String Youtube { get; set; }
    public String PrimaryColor { get; set; }
    public String SecondaryColor { get; set; }
    
    public List<String> TiposMembresia { get; set; }
}