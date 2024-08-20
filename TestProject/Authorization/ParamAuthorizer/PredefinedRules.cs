using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject.Validation.ParamAuthorizer;

public static class PredefinedRules
{
    public static RuleSet ExternalRoles(this RuleSet ruleSet, List<string> allowedExternalRoles)
    {
        ruleSet.AddRule(instance => instance.Roles.Any(assignedRole =>
            allowedExternalRoles.Contains(assignedRole, StringComparer.OrdinalIgnoreCase)));
        return ruleSet;
    }

    public static RuleSet InternalRoles(this RuleSet ruleSet, List<string> allowedInternalRoles)
    {
        ruleSet.AddRule(instance => instance.InternalRoles.Any(assignedRole =>
            allowedInternalRoles.Contains(assignedRole, StringComparer.OrdinalIgnoreCase)));
        return ruleSet;
    }

    public static RuleSet IsMemberType(this RuleSet ruleSet)
    {
        ruleSet.AddRule(validParams => MemberTypes.IsMemberType(validParams.Member.MemberType));
        return ruleSet;
    }

    public static RuleSet IsMemberServicer(this RuleSet ruleSet)
    {
        ruleSet.AddRule(validParams => validParams.Member.MemberType.HasValue &&
                                       MemberTypes.IsMemberServicer(validParams.Member.MemberType.Value));
        return ruleSet;
    }

    public static RuleSet IsEffective(this RuleSet ruleSet)
    {
        ruleSet.AddRule(validParams => validParams.Member.EffectiveDate <= validParams.Date);
        return ruleSet;
    }

    public static RuleSet IsNonEffective(this RuleSet ruleSet)
    {
        ruleSet.AddRule(validParams => validParams.Member.EffectiveDate > validParams.Date);
        return ruleSet;
    }

    public static RuleSet HasAgreementOneSigned(this RuleSet ruleSet)
    {
        ruleSet.AddRule(validParams => validParams.Member.SignedOne);
        return ruleSet;
    }

    public static RuleSet HasAgreementTwoSigned(this RuleSet ruleSet)
    {
        ruleSet.AddRule(validParams => validParams.Member.SignedOne);
        return ruleSet;
    }

    public static RuleSet HasAgreementThreeSigned(this RuleSet ruleSet)
    {
        ruleSet.AddRule(validParams => validParams.Member.SignedOne);
        return ruleSet;
    }
}