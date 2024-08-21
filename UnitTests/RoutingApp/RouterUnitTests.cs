using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RoutingApp;
using RoutingApp.BookActivityOperations;
using RoutingApp.DummyResources;

namespace UnitTests.RoutingApp;

public class RouterUnitTests
{
    private BookActivityRouter _router;


    public RouterUnitTests()
    {
        _router = new BookActivityRouter();
    }

    [Fact]
    public async Task TestTask()
    {
        var parameters = new RouterParameters(IntegrationAction.Approved, null, new AddBookRequest(), null);

        var operationName = _router.GetOperation(parameters);

        operationName.Should().Be(nameof(AddBookApproved));
    }
}