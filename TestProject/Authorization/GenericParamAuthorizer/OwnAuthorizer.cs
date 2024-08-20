namespace TestProject.Validation.GenericParamAuthorizer;

public class OwnAuthorizer : ParamAuthorizer<IParams>
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