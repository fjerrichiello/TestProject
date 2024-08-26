namespace DataSeeding.Models;

public class BoundedContextSeedData
{
    public BoundedContextSeedData(string boundedContextName)
    {
        BoundedContextName = boundedContextName;
    }

    public string BoundedContextName { get; set; }

    public List<Assignment> Assignments { get; set; } = [];
    public List<InternalAssignment> InternalAssignments { get; set; } = [];
    public List<Member> Members { get; set; } = [];
    public List<User> Users { get; set; } = [];


    public void AddUser(bool IsInternal, List<string> actions, string Role)
    {
        var userName =
            $"{(IsInternal ? "Internal" : "External")} {BoundedContextName} {Role} {string.Join('/', actions)}";
        Users.Add(new User(Guid.NewGuid(), userName, IsInternal));
    }
}