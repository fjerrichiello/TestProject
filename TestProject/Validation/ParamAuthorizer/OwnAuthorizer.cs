namespace TestProject.Validation.ParamAuthorizer;

public class OwnAuthorizer : ParamAuthorizer
{
    public OwnAuthorizer()
    {
        AddRuleSet(
            IsEffectiveMember()
                .Roles(["test"], ["Super"]));

        AddRuleSet(IsNonEffectiveMember()
            .ExternalRoles(["MSA"]));

        AddRuleSet(IsEffectiveServicer()
            .InternalRoles(["VCA"]));
    }
}