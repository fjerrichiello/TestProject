using HttpPassthroughWrapper.Client.Models;

namespace HttpPassthroughWrapper.WithMapper;

public class ModelMapper : IMapper<PokeApiResponse, PokemonApiDto>
{
    public PokemonApiDto Map(PokeApiResponse input)
    {
        return new PokemonApiDto(input.Name);
    }
}