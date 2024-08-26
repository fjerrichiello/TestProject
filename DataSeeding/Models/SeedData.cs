namespace DataSeeding.Models;

public class SeedData
{
    public List<Role> Roles { get; set; } = [];

    public List<BoundedContextSeedData> BoundedContexts = [];
}