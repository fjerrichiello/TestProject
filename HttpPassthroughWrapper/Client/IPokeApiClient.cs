using HttpPassthroughWrapper.Client.Models;

namespace HttpPassthroughWrapper.Client;

public interface IPokeApiClient : IClient
{
    Task<PokeApiResponse?> GetPokemonById(int id);

    Task<PokeApiResponse?> GetPokemonByName(string name);
}