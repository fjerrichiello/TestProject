using Dumpify;

namespace TestProject.Validation.ParamAuthorizer;

public class RuleSet
{
    private readonly List<(Func<IParams, bool> Rule, string ErrorMessage)> _rules = new();

    public RuleSet AddRule(Func<IParams, bool> rule, string errorMessage = "Error")
    {
        _rules.Add((rule, errorMessage));
        return this;
    }

    public bool Authorize(IParams instance)
    {
        return _rules.TrueForAll(x =>
        {
            $"Rule {x.Rule(instance).ToString()}".Dump();
            return x.Rule(instance);
        });
    }
}