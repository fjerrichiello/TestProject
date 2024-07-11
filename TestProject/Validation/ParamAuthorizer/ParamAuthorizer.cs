using System.Collections.Generic;
using System.Linq;
using Dumpify;

namespace TestProject.Validation.ParamAuthorizer;

public abstract class ParamAuthorizer
{
    private readonly List<RuleSet> _ruleSets = [];

    protected RuleSet IsEffectiveMember()
    {
        var result = new RuleSet();
        result.IsEffective()
            .IsMemberType()
            .HasAgreementOneSigned()
            .HasAgreementTwoSigned();
        return result;
    }

    protected RuleSet IsNonEffectiveMember()
    {
        var result = new RuleSet();
        result.IsNonEffective()
            .IsMemberType()
            .HasAgreementOneSigned()
            .HasAgreementTwoSigned();
        return result;
    }

    protected RuleSet IsEffectiveServicer()
    {
        var result = new RuleSet();
        result.IsEffective()
            .IsMemberServicer()
            .HasAgreementThreeSigned();
        return result;
    }

    public ParamAuthorizer AddRuleSet(RuleSet ruleSet)
    {
        _ruleSets.Add(ruleSet);
        return this;
    }

    public bool Authorize(IParams test)
    {
        return _ruleSets.Any(rs =>
        {
            "Sequence".Dump();
             return rs.Authorize(test);
        });
    }
}