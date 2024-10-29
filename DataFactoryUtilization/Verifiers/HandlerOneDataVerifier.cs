using DataFactoryUtilization.Authorizers;
using DataFactoryUtilization.Factories;
using DataFactoryUtilization.Handlers;
using DataFactoryUtilization.Validators;

namespace DataFactoryUtilization.Verifiers;

public class
    HandlerOneDataVerifier() : IVerifier<HandlerOneData, HandlerOneValidData>
{
    public VerificationResult<HandlerOneValidData> Verify(
        HandlerOneData parameters)
    {
        var verificationResult = new VerificationResult<HandlerOneValidData>();

        verificationResult.Authorize(new DataAuthorizer());

        if (!verificationResult.Success)
        {
            return verificationResult;
        }

        verificationResult.Validate(new DataValidator());

        if (!verificationResult.Success)
        {
            return verificationResult;
        }


        verificationResult.SuccessResult = new HandlerOneValidData(
            parameters.Value1.Value, parameters.Value2.Value,
            parameters.Value3);

        return verificationResult;
    }
}
