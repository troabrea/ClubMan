using System.ComponentModel.DataAnnotations;

namespace ClubMan.Web.Auth;

public class LoginModel
{
    [Required(ErrorMessage = "Debe especificar un nombre de usuario.")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Debe especificar una clave de acceso.")]
    public string Password { get; set; }
}