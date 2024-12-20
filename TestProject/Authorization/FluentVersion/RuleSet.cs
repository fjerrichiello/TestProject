﻿using System;
using System.Collections.Generic;
using Dumpify;

namespace TestProject.Validation.FluentVersion;

public class RuleSet<T>
{
    private readonly List<(Func<T, bool> Rule, string ErrorMessage)> _rules = new();

    public RuleSet<T> AddRule(Func<T, bool> rule, string errorMessage = "Error")
    {
        _rules.Add((rule, errorMessage));
        return this;
    }

    public bool Authorize(T instance)
    {
        return _rules.TrueForAll(rule =>
        {
            "Checking Rule".Dump();
            return rule.Rule(instance);
        });
    }
}