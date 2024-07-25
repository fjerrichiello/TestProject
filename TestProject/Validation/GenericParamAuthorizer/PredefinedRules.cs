namespace TestProject.Validation.GenericParamAuthorizer;

public static class PredefinedRules
{
    public static RuleSet<IParams> ExternalRoles(this RuleSet<IParams> ruleSet, List<string> allowedExternalRoles)
    {
        ruleSet.AddRule(instance => instance.Roles.Any(assignedRole =>
            allowedExternalRoles.Contains(assignedRole, StringComparer.OrdinalIgnoreCase)));
        return ruleSet;
    }

    public static RuleSet<IParams> InternalRoles(this RuleSet<IParams> ruleSet, List<string> allowedInternalRoles)
    {
        ruleSet.AddRule(instance => instance.InternalRoles.Any(assignedRole =>
            allowedInternalRoles.Contains(assignedRole, StringComparer.OrdinalIgnoreCase)));
        return ruleSet;
    }

    public static RuleSet<IParams> IsMemberType(this RuleSet<IParams> ruleSet)
    {
        ruleSet.AddRule(validParams => MemberTypes.IsMemberType(validParams.Member.MemberType));
        return ruleSet;
    }

    public static RuleSet<IParams> IsMemberServicer(this RuleSet<IParams> ruleSet)
    {
        ruleSet.AddRule(validParams => validParams.Member.MemberType.HasValue &&
                                       MemberTypes.IsMemberServicer(validParams.Member.MemberType.Value));
        return ruleSet;
    }

    public static RuleSet<IParams> IsEffective(this RuleSet<IParams> ruleSet)
    {
        ruleSet.AddRule(validParams => validParams.Member.EffectiveDate <= validParams.Date);
        return ruleSet;
    }

    public static RuleSet<IParams> IsNonEffective(this RuleSet<IParams> ruleSet)
    {
        ruleSet.AddRule(validParams => validParams.Member.EffectiveDate > validParams.Date);
        return ruleSet;
    }

    public static RuleSet<IParams> HasAgreementOneSigned(this RuleSet<IParams> ruleSet)
    {
        ruleSet.AddRule(validParams => validParams.Member.SignedOne);
        return ruleSet;
    }

    public static RuleSet<IParams> HasAgreementTwoSigned(this RuleSet<IParams> ruleSet)
    {
        ruleSet.AddRule(validParams => validParams.Member.SignedOne);
        return ruleSet;
    }

    public static RuleSet<IParams> HasAgreementThreeSigned(this RuleSet<IParams> ruleSet)
    {
        ruleSet.AddRule(validParams => validParams.Member.SignedOne);
        return ruleSet;
    }
}