using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace TestProject.Validation.FluentValidation;

public class AbstractAuthorizer : AbstractValidator<ValidParams>
{
    public AbstractAuthorizer()
    {
        RuleSet("HasEffectivePermissions", () =>
        {
            RuleFor(x => x.Member.MemberType).Must(MemberTypes.IsMemberType);
            RuleFor(x => x.Member.EffectiveDate).LessThanOrEqualTo(x => x.Member.EffectiveDate);
            RuleFor(x => x.Member.SignedOne).Equals(true);
            RuleFor(x => x.Member.SignedTwo).Equals(true);
            RuleFor(x => x.Roles).Must(x => x.Any(y => HasInternalRole(y) || HasExternalRole(y)));
        });

        RuleSet("HasNonEffectivePermissions", () =>
        {
            RuleFor(x => x.Member.MemberType).Must(MemberTypes.IsMemberType);
            RuleFor(x => x.Member.EffectiveDate).GreaterThan(x => x.Member.EffectiveDate);
            RuleFor(x => x.Member.SignedOne).Equals(true);
            RuleFor(x => x.Member.SignedTwo).Equals(true);
            RuleFor(x => x.Roles).Must(x => x.Any(HasInternalRole));
        });

        RuleSet("HasEffectiveNonMemberServicerCustodialPermissions", () =>
        {
            RuleFor(x => x.Member.MemberType).Must(x => x.HasValue && MemberTypes.IsMemberServicer(x.Value));
            RuleFor(x => x.Member.EffectiveDate).LessThanOrEqualTo(x => x.Member.EffectiveDate);
            RuleFor(x => x.Member.SignedThree).Equals(true);
            RuleFor(x => x.Roles).Must(x => x.Any(HasExternalRole));
        });
    }

    private static bool HasInternalRole(string role)
    {
        var list = new List<string> { "test" };
        return list.Contains(role);
    }

    private static bool HasExternalRole(string role)
    {
        var list = new List<string> { "test2" };
        return list.Contains(role);
    }
}