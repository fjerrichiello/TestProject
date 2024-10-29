namespace DataFactoryUtilization.Verifiers;

public interface IVerifier<in TParameters, TResult>
{
    Task<VerificationResult<TResult>> Verify(
        TParameters parameters);
}
