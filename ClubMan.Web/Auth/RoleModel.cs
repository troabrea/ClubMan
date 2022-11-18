namespace ClubMan.Web.Auth;

public record RoleModel
{
    public string Name { get; set; } = string.Empty;
    public int Value { get; set; } 

    public static List<RoleModel> SystemRoles()
    {
        var result = new List<RoleModel>();
        result.Add(new RoleModel() {Name = "Regular", Value = 0});
        result.Add(new RoleModel() {Name = "Administrador", Value = 3});
        result.Add(new RoleModel() {Name = "Sistema", Value = 1});
        return result;
    }

    public static string RoleName(int value)
    {
        return value switch
        {
            0 => "Regular",
            3 => "Administrador",
            1 => "Sistema",
            _ => string.Empty
        };
    }
}