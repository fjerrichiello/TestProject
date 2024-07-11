using System;
using System.Collections.Generic;
using FluentAssertions;
using TestProject.Validation;
using TestProject.Validation.ParamAuthorizer;
using Xunit;
using Xunit.Abstractions;

namespace UnitTests.Validation.ParamAuthorizer;

public class ParamAuthorizerTest
{
    private static readonly OwnAuthorizer Authorizer = new();

    private readonly ITestOutputHelper _output;


    public ParamAuthorizerTest(ITestOutputHelper output)
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