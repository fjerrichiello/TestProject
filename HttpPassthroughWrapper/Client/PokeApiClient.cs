using HttpPassthroughWrapper.Client.Models;

namespace HttpPassthroughWrapper.Client;

public class PokeApiClient : IPokeApiClient
{
    private readonly HttpClient _httpClient;

    private const string GetPokemonPath = "pokemon/{0}";

    public PokeApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
    }

    public async Task<PokeApiResponse?> GetPokemonById(int id)
    {
        var requestPath = string.Format(GetPokemonPath, id);
        var response = await Get(requestPath);
        if (response is null) throw new Exception();
        return response;
    }

    public async Task<PokeApiResponse?> GetPokemonByName(string name)
    {
        var requestPath = string.Format(GetPokemonPath, name);
        var response = await Get(requestPath);
        if (response is null) throw new Exception();
        return response;
    }


    private async Task<PokeApiResponse?> Get(string route)
        => await _httpClient.GetFromJsonAsync<PokeApiResponse>(route);
}