namespace HttpPassthroughWrapper.Client.Models;

public class PokeApiPokemonType
{
    public int Slot { get; set; }

    public PokeApiType Type { get; set; } = null!;
}