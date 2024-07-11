using Dumpify;

namespace TestProject.Validation.FluentVersion;

public abstract class AbstractAuthorizer<T>
{
    private readonly List<RuleSet<T>> _ruleSets = new();

    private void AddRuleSet(RuleSet<T> ruleSet)
    {
        _ruleSets.Add(ruleSet);
    }

    public bool Authorize(T instance)
    {
        List<string> errors = [];

        return _ruleSets.Any(ruleSet =>
        {
            "Checking Rule Set".Dump();
            return ruleSet.Authorize(instance);
        });
    }

    protected AbstractAuthorizer<T> Is(Func<AbstractAuthorizer<T>, FluentRuleSet<T>> ruleSetFunc)
    {
        var ruleSet = ruleSetFunc(this).GetRuleSet();
        AddRuleSet(ruleSet);
        return this;
    }
}