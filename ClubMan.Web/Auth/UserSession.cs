namespace ClubMan.Web.Auth;

public class UserSession 
{
    public string UserId { get; set; } = String.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Role { get; set; }
    public string ClubName { get; set; }
    public string ClubKey { get; set; }
    
    public string PrimaryColor { get; set; }
    public string SecondaryColor { get; set; }
    public string LogoUrl { get; set; }
}