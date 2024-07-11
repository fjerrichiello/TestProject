using FluentValidation;

namespace TestProject.Validation.FluentValidation;

public class Authorizer2 : AbstractValidator<ValidParams>
{
    public Authorizer2()
    {
        RuleSet("IsMemberEffective",
            () => { RuleFor(x => x.Member.EffectiveDate).LessThanOrEqualTo(x => x.Member.EffectiveDate); });

        RuleSet("IsMemberIneffective",
            () => { RuleFor(x => x.Member.EffectiveDate).GreaterThan(x => x.Member.EffectiveDate); });

        RuleSet("IsMember", () => { RuleFor(x => x.Member.MemberType).Must(MemberTypes.IsMemberType); });

        RuleSet("IsMemberServicer",
            () =>
            {
                RuleFor(x => x.Member.MemberType).Must(x => x.HasValue && MemberTypes.IsMemberServicer(x.Value));
            });

        RuleSet("HasOneAndTwoSigned", () =>
        {
            RuleFor(x => x.Member.SignedOne).Equals(true);
            RuleFor(x => x.Member.SignedTwo).Equals(true);
        });

        RuleSet("HasThreeSigned", () => { RuleFor(x => x.Member.SignedThree).Equals(true); });

        RuleSet("HasAnyRole",
            () => { RuleFor(x => x.Roles).Must(x => x.Any(y => HasInternalRole(y) || HasExternalRole(y))); });

        RuleSet("HasExternalRole",
            () => { RuleFor(x => x.Roles).Must(x => x.Any(HasExternalRole)); });

        RuleSet("HasInternalRole",
            () => { RuleFor(x => x.Roles).Must(x => x.Any(HasInternalRole)); });
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