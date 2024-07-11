using TestProject.Validation;
using TestProject.Validation.ParamAuthorizer;

var ownAuth = new OwnAuthorizer();

var member = new Member(Guid.NewGuid(), MemberType.Member, true, true, true,
    DateOnly.FromDateTime(DateTime.UtcNow));

var test = new ValidParams(member, ["test"], new List<string>(),
    DateOnly.FromDateTime(DateTime.UtcNow));

ownAuth.Authorize(test);