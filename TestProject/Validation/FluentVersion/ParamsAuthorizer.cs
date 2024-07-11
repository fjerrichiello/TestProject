namespace TestProject.Validation.FluentVersion;

public class ParamsAuthorizer : AbstractParamsAuthorizer
{
    public ParamsAuthorizer()
    {
        Is(_ => Effective().InternalRoles(["test"]).ExternalRoles(["test"]));

        Is(_ => NonEffective().ExternalRoles(["MSA"]));

        Is(_ => EffectiveServicer().InternalRoles(["test"]));
    }
}