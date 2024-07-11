using FluentAssertions;
using TestProject.Validation;
using TestProject.Validation.FluentVersion;
using Xunit.Abstractions;

namespace UnitTests.Validation.FluentVersion;

public class FluentAuthorizerTest
{
    private static readonly ParamsAuthorizer Authorizer = new();

    private readonly ITestOutputHelper _output;


    public FluentAuthorizerTest(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void Test1()
    {
        var member = new Member(Guid.NewGuid(), MemberType.Member, true, true, true,
            DateOnly.FromDateTime(DateTime.UtcNow));

        var test = new ValidParams(member, ["test"], new List<string>(),
            DateOnly.FromDateTime(DateTime.UtcNow));

        var authorizerTest = Authorizer.Authorize(test);
        authorizerTest.Should().BeTrue();
    }
}