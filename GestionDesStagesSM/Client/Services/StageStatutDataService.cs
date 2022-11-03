using GestionDesStagesSM.Client.Interfaces;
using GestionDesStagesSM.Shared.Modele;
using System.Net.Http;
using System.Text.Json;

public class StageStatutDataService : IStageStatutDataService
{
    private readonly HttpClient _httpClient;

    public StageStatutDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<StageStatut>> GetAllStageStatuts()
    {
        
            // Si parametre null source : si Chrome flusher l'historique
            return await JsonSerializer.DeserializeAsync<IEnumerable<StageStatut>>
                (await _httpClient.GetStreamAsync($"api/stagestatut"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        
    }
}