using System;
using System.Collections.Generic;
using TestProject.Validation;
using TestProject.Validation.FluentVersion;

var ownAuth = new ParamsAuthorizer();

var member = new Member(Guid.NewGuid(), MemberType.Member, true, true, true,
    DateOnly.FromDateTime(DateTime.UtcNow));

var test = new ValidParams(member, ["test"], new List<string>(),
    DateOnly.FromDateTime(DateTime.UtcNow));

ownAuth.Authorize(test);