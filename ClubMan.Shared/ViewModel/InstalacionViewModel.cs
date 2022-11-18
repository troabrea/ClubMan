using ClubMan.Shared.Model;

namespace ClubMan.Shared.ViewModel;

public class InstalacionViewModel
{
    public Guid Id { get; set; }
    public Instalacion Instalacion { get; set; }
    public Localidad Localidad { get; set; }
}