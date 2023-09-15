using ClubMan.Shared.Model;

namespace ClubMan.Web.Services;

public partial class ApiService : IApiService
{
    public Task<List<Cortesia>> GetCortesias(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<Cortesia>>("Cortesia");
    }

    public async Task UpsertCortesia(string apiKey, Cortesia cortesia, bool isNew)
    {
        SetupClient(apiKey);
        await (isNew ? _httpClient.PostAsJsonAsync("Cortesia", cortesia) : _httpClient.PutAsJsonAsync("Cortesia", cortesia));
    }

    public Task RemoveCortesia(string apiKey, long cortesiaId)
    {
        return _httpClient.DeleteAsync($"Cortesia/{cortesiaId}");
    }
}