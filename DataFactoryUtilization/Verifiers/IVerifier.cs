namespace DataFactoryUtilization.Verifiers;

public interface IVerifier<in TParameters, TResult>
{
    VerificationResult<TResult> Verify(
        TParameters parameters);
}
