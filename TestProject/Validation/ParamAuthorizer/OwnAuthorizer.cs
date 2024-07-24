using Spectre.Console;

namespace TestProject.Validation.ParamAuthorizer;

public class OwnAuthorizer : ParamAuthorizer
{
    public OwnAuthorizer()
    {
        //Effective member in org
        Is(member
            => member.IsEffective()
                .IsMemberType()
                .HasAgreementOneSigned()
                .HasAgreementTwoSigned()
                .InternalRoles(["SuperAdmin"]));

        Is(member
            => member.IsEffective()
                .IsMemberType()
                .HasAgreementOneSigned()
                .HasAgreementTwoSigned()
                .ExternalRoles(["MSA"]));

        Is(member
            => member.IsNonEffective()
                .IsMemberType()
                .HasAgreementOneSigned()
                .HasAgreementTwoSigned()
                .InternalRoles(["SuperAdmin"]));

        Is(member
            => member.IsEffective()
                .IsMemberServicer()
                .HasAgreementThreeSigned()
                .ExternalRoles(["MSA"]));
    }
}