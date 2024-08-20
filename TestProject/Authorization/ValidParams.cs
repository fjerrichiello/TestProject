using System;
using System.Collections.Generic;

namespace TestProject.Validation;

public record ValidParams(IMember Member, List<string> Roles, List<string> InternalRoles, DateOnly Date) : IParams;