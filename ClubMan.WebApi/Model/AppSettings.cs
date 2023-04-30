namespace ClubMan.WebApi.Model;

public class AppSettings
{
    public static string ConfigKey => "AppSettings";

    public string SmsApiUrl { get; set; }
    public string SmsApiKey { get; set; }
    public string SmsPlataform { get; set; }
    public string ShortUrlApiKey { get; set; }
    public string ShortUrlDomain { get; set; }

    public string CleanupProcessSchedule { get; set; }

}