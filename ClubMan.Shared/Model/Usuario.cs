namespace ClubMan.Shared.Model;

public record Usuario
{
    public Usuario()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public Guid EmpresaId { get; set; }
    public string UsuarioId { get; set; }
    public string Nombre { get; set; }
    public string Rol { get; set; } = "Manager";
    public string ClaveHash { get; set; }= "";
    public string ClaveSalt { get; set; } = "";
    public bool Activo { get; set; } = true;
}