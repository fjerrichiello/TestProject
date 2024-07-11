namespace TestProject.Validation.FluentVersion;

public abstract class AbstractParamsAuthorizer : AbstractAuthorizer<IParams>
{
    protected FluentRuleSet<IParams> Effective()
    {
        var fluentRuleSet = new FluentRuleSet<IParams>(this);
        fluentRuleSet.IsEffective()
            .IsMemberType()
            .HasAgreementOneSigned()
            .HasAgreementTwoSigned();
        return fluentRuleSet;
    }

    protected FluentRuleSet<IParams> NonEffective()
    {
        var fluentRuleSet = new FluentRuleSet<IParams>(this);
        fluentRuleSet.IsNonEffective()
            .IsMemberType()
            .HasAgreementOneSigned()
            .HasAgreementTwoSigned();
        return fluentRuleSet;
    }

    protected FluentRuleSet<IParams> EffectiveServicer()
    {
        var fluentRuleSet = new FluentRuleSet<IParams>(this);
        fluentRuleSet.IsEffective()
            .IsMemberServicer()
            .HasAgreementThreeSigned();
        return fluentRuleSet;
    }
}