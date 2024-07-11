namespace TestProject.Validation;

public interface IParams
{
    public IMember Member { get; init; }
    public List<string> Roles { get; init; }
    public List<string> InternalRoles { get; init; }
    public DateOnly Date { get; init; }
};