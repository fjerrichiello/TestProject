using HttpPassthroughWrapper.Client.Models;

namespace HttpPassthroughWrapper.Client;

public interface IPokeApiClient
{
    Task<PokeApiResponse?> GetPokemonById(int id);

    Task<PokeApiResponse?> GetPokemonByName(string name);
}