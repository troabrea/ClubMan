using System.Text.Encodings.Web;
using ClubMan.Shared.Events;
using ClubMan.Shared.Model;
using ClubMan.Web.Components;

namespace ClubMan.Web.Services;



public partial class ApiService : IApiService
{
    public Task<List<Socio>> GetSocios(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<Socio>>("Socio");
    }
    public Task<Socio> GetSocio(string apiKey, long socioId)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<Socio>($"Socio/{socioId}");
    }

    public async Task<Socio> UpdateSocioGenerales(string apiKey, Socio socio)
    {
        SetupClient(apiKey);
        var reqResult = await _httpClient.PostAsJsonAsync("Socio/generales", socio);
        reqResult.EnsureSuccessStatusCode();
        var result = await reqResult.Content.ReadFromJsonAsync<Socio>();
        return result;
    }
    public async Task<Socio> UpsertSocioAdicional(AppState appState, long socioId,  AdicionalSocio adicionalSocio)
    {
        SetupClient(appState.ClubKey);
        var agregarEvent = new AgregarAdicionalEvent( socioId,appState.UserName, adicionalSocio );
        await _httpClient.PostAsJsonAsync($"Socio/adicional/{socioId}", agregarEvent);
        return await _httpClient.GetFromJsonAsync<Socio>($"Socio/{socioId}");  
    }
    public async Task<Socio> ReActivateSocioAdicional(AppState appState, long socioId,  AdicionalSocio adicionalSocio)
    {
        SetupClient(appState.ClubKey);
        var agregarEvent = new AgregarAdicionalEvent( socioId,appState.UserName, adicionalSocio );
        await _httpClient.PostAsJsonAsync($"Socio/adicional/activar", agregarEvent);
        return await _httpClient.GetFromJsonAsync<Socio>($"Socio/{socioId}");  
    }
    public async Task<Socio> DeActivateSocioAdicional(AppState appState, long socioId,  AdicionalSocio adicionalSocio)
    {
        SetupClient(appState.ClubKey);
        var agregarEvent = new AgregarAdicionalEvent( socioId,appState.UserName, adicionalSocio );
        await _httpClient.PostAsJsonAsync($"Socio/adicional/cancelar", agregarEvent);
        return await _httpClient.GetFromJsonAsync<Socio>($"Socio/{socioId}");  
    }
    public async Task<Socio> UpsertSocioDependiente(AppState appState, long socioId,  DependienteSocio dependienteSocio)
    {
        SetupClient(appState.ClubKey);
        var agregarEvent = new AgregarDependienteEvent( socioId,appState.UserName, dependienteSocio );
        await _httpClient.PostAsJsonAsync($"Socio/dependiente/{socioId}", agregarEvent);
        return await _httpClient.GetFromJsonAsync<Socio>($"Socio/{socioId}");  
    }
    public async Task<Socio> DeActivateSocioDependiente(AppState appState, long socioId,  DependienteSocio dependienteSocio)
    {
        SetupClient(appState.ClubKey);
        var agregarEvent = new AgregarDependienteEvent( socioId,appState.UserName, dependienteSocio );
        await _httpClient.PostAsJsonAsync($"Socio/dependiente/cancelar", agregarEvent);
        return await _httpClient.GetFromJsonAsync<Socio>($"Socio/{socioId}");  
    }
    public async Task<Socio> ReActivateSocioDependiente(AppState appState, long socioId,  DependienteSocio dependienteSocio)
    {
        SetupClient(appState.ClubKey);
        var agregarEvent = new AgregarDependienteEvent(socioId,appState.UserName, dependienteSocio );
        await _httpClient.PostAsJsonAsync($"Socio/dependiente/activar", agregarEvent);
        return await _httpClient.GetFromJsonAsync<Socio>($"Socio/{socioId}");  
    }
    
    public async Task<Socio> UpsertSocioHuesped(AppState appState, long socioId,  HuespedSocio huespedSocio)
    {
        SetupClient(appState.ClubKey);
        var agregarEvent = new AgregarHuespedEvent( socioId,appState.UserName, huespedSocio );
        await _httpClient.PostAsJsonAsync($"Socio/huesped/{socioId}", agregarEvent);
        return await _httpClient.GetFromJsonAsync<Socio>($"Socio/{socioId}");  
    }
    public async Task<Socio> ReActivateSocioHuesped(AppState appState, long socioId,  HuespedSocio huespedSocio)
    {
        SetupClient(appState.ClubKey);
        var agregarEvent = new AgregarHuespedEvent(socioId,appState.UserName, huespedSocio );
        await _httpClient.PostAsJsonAsync($"Socio/huesped/activar", agregarEvent);
        return await _httpClient.GetFromJsonAsync<Socio>($"Socio/{socioId}");  
    }
    public async Task<Socio> DeActivateSocioHuesped(AppState appState, long socioId,  HuespedSocio huespedSocio)
    {
        SetupClient(appState.ClubKey);
        var agregarEvent = new AgregarHuespedEvent( socioId,appState.UserName, huespedSocio );
        await _httpClient.PostAsJsonAsync($"Socio/huesped/cancelar", agregarEvent);
        return await _httpClient.GetFromJsonAsync<Socio>($"Socio/{socioId}");  
    }
    
    public async Task<Socio> DeleteAdicional(string apiKey, long socioId, long adicionalId)
    {
        SetupClient(apiKey);
        await _httpClient.DeleteAsync($"Socio/adicional/{socioId}/{adicionalId}");
        return await _httpClient.GetFromJsonAsync<Socio>($"Socio/{socioId}");
    }

    public async Task<Socio> UpsertEmbarcacion(string apiKey, long socioId, Embarcacion embarcacion)
    {
        SetupClient(apiKey);
        await _httpClient.PostAsJsonAsync($"Socio/embarcacion/{socioId}", embarcacion);
        return await _httpClient.GetFromJsonAsync<Socio>($"Socio/{socioId}");
    }

    public async Task<Socio> DeleteEmbarcacion(string apiKey, long socioId, Embarcacion embarcacion)
    {
        SetupClient(apiKey);
        await _httpClient.PostAsJsonAsync($"Socio/embarcacion/remove/{socioId}", embarcacion);
        return await _httpClient.GetFromJsonAsync<Socio>($"Socio/{socioId}");
    }

    public Task<List<MovimientoSocio>> GetAprobacionesPendientes(string apiKey)
    {
        SetupClient(apiKey);
        return _httpClient.GetFromJsonAsync<List<MovimientoSocio>>("Movimientos");
    }

    public async Task ProcesaMovimento(string apiKey, ProcesaMovimientoEvent procesaEvent)
    {
        SetupClient(apiKey);
        var result = await _httpClient.PostAsJsonAsync($"Movimientos/procesar", procesaEvent);
        result.EnsureSuccessStatusCode();
    }

    
}