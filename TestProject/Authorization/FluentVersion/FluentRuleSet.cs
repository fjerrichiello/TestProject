using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject.Validation.FluentVersion;

public class FluentRuleSet<T>
{
    private readonly RuleSet<T> _ruleSet = new();
    private readonly AbstractAuthorizer<T> _abstractAuthorizer;

    private List<string> _externalRoles = [];
    private List<string> _internalRoles = [];

    public FluentRuleSet(AbstractAuthorizer<T> abstractAuthorizer)
    {
        _abstractAuthorizer = abstractAuthorizer;
    }

    public FluentRuleSet<T> AddRule(Func<T, bool> rule, string errorMessage = "Error")
    {
        _ruleSet.AddRule(rule, errorMessage);
        return this;
    }

    public FluentRuleSet<T> InternalRoles(List<string> internalRoles)
    {
        _internalRoles = internalRoles;
        return this;
    }

    public FluentRuleSet<T> ExternalRoles(List<string> externalRoles)
    {
        _externalRoles = externalRoles;
        return this;
    }

    public RuleSet<T> GetRuleSet()
    {
        if (_externalRoles.Any() && _internalRoles.Any())
        {
            _ruleSet.AddRule(instance =>
                {
                    var validParams = instance as IParams;
                    return _externalRoles.Any(role => validParams?.Roles.Contains(role) ?? false) ||
                           _internalRoles.Any(role => validParams?.InternalRoles.Contains(role) ?? false);
                },
                $"Customer must have either the roles: {string.Join(", ", _externalRoles)} or internal roles: {string.Join(", ", _internalRoles)}");
        }

        return _ruleSet;
    }
}