using ClubMan.Shared.ViewModel;
using ClubMan.Shared.Model;


namespace ClubMan.Web.Services;

public interface ISystemApiService
{
    Task<LoggedUserViewModel> LoginUser(string usuario, string clave);
    Task<Empresa> GetEmpresa(string empresaId);
    Task<Usuario> GetUsuario(string usuarioId);
    Task UpdateUsuario(Usuario usuario);
}