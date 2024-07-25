using Dumpify;

namespace TestProject.Validation.GenericParamAuthorizer;

public abstract class ParamAuthorizer<T>
{
    private readonly List<RuleSet<T>> _ruleSets = [];

    protected void Is(Func<RuleSet<T>, RuleSet<T>> ruleSetFunc)
    {
        var ruleSet = new RuleSet<T>();
        ruleSet = ruleSetFunc(ruleSet);
        AddRuleSet(ruleSet);
    }

    private void AddRuleSet(RuleSet<T> ruleSet)
    {
        _ruleSets.Add(ruleSet);
    }

    public bool Authorize(T test)
    {
        return _ruleSets.Any(rs =>
        {
            "Sequence".Dump();
            return rs.Authorize(test);
        });
    }
}