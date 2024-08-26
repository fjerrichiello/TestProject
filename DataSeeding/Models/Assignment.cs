namespace DataSeeding.Models;

public record Assignment(Guid Id, Guid RoleId, Guid MemberId, Guid User);