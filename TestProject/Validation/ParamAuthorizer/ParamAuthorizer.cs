using System.Collections.Generic;
using System.Linq;
using Dumpify;

namespace TestProject.Validation.ParamAuthorizer;

public abstract class ParamAuthorizer
{
    private readonly List<RuleSet> _ruleSets = [];

    protected void Is(Func<RuleSet, RuleSet> ruleSetFunc)
    {
        var ruleSet = new RuleSet();
        ruleSet = ruleSetFunc(ruleSet);
        AddRuleSet(ruleSet);
    }

    private void AddRuleSet(RuleSet ruleSet)
    {
        _ruleSets.Add(ruleSet);
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