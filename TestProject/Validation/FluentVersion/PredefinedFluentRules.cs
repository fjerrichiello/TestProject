namespace TestProject.Validation.FluentVersion;

public static class PredefinedFluentRules
{
    public static FluentRuleSet<IParams> HasRoles(this FluentRuleSet<IParams> ruleSet, List<string> externalRoles,
        List<string> internalRoles)
    {
        ruleSet.AddRule(instance => instance.Roles.Any(assignedRole =>
                                        externalRoles.Contains(assignedRole,
                                            StringComparer.OrdinalIgnoreCase)) ||
                                    instance.InternalRoles.Any(assignedInternalRole =>
                                        internalRoles.Contains(assignedInternalRole,
                                            StringComparer.OrdinalIgnoreCase)));
        return ruleSet;
    }

    public static FluentRuleSet<IParams> HasExternalRoles(this FluentRuleSet<IParams> ruleSet,
        List<string> externalRoles)
    {
        ruleSet.AddRule(instance => instance.Roles.Any(assignedRole =>
            externalRoles.Contains(assignedRole, StringComparer.OrdinalIgnoreCase)));
        return ruleSet;
    }

    public static FluentRuleSet<IParams> HasInternalRoles(this FluentRuleSet<IParams> ruleSet,
        List<string> internalRoles)
    {
        ruleSet.AddRule(instance => instance.InternalRoles.Any(assignedRole =>
            internalRoles.Contains(assignedRole, StringComparer.OrdinalIgnoreCase)));
        return ruleSet;
    }

    public static FluentRuleSet<IParams> IsMemberType(this FluentRuleSet<IParams> ruleSet)
    {
        ruleSet.AddRule(validParams => MemberTypes.IsMemberType(validParams.Member.MemberType));
        return ruleSet;
    }

    public static FluentRuleSet<IParams> IsMemberServicer(this FluentRuleSet<IParams> ruleSet)
    {
        ruleSet.AddRule(validParams => validParams.Member.MemberType.HasValue &&
                                       MemberTypes.IsMemberServicer(validParams.Member.MemberType.Value));
        return ruleSet;
    }

    public static FluentRuleSet<IParams> IsEffective(this FluentRuleSet<IParams> ruleSet)
    {
        ruleSet.AddRule(validParams => validParams.Member.EffectiveDate <= validParams.Date);
        return ruleSet;
    }

    public static FluentRuleSet<IParams> IsNonEffective(this FluentRuleSet<IParams> ruleSet)
    {
        ruleSet.AddRule(validParams => validParams.Member.EffectiveDate > validParams.Date);
        return ruleSet;
    }

    public static FluentRuleSet<IParams> HasAgreementOneSigned(this FluentRuleSet<IParams> ruleSet)
    {
        ruleSet.AddRule(validParams => validParams.Member.SignedOne);
        return ruleSet;
    }

    public static FluentRuleSet<IParams> HasAgreementTwoSigned(this FluentRuleSet<IParams> ruleSet)
    {
        ruleSet.AddRule(validParams => validParams.Member.SignedOne);
        return ruleSet;
    }

    public static FluentRuleSet<IParams> HasAgreementThreeSigned(this FluentRuleSet<IParams> ruleSet)
    {
        ruleSet.AddRule(validParams => validParams.Member.SignedOne);
        return ruleSet;
    }
}