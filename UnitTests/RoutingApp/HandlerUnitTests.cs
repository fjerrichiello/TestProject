using AutoFixture;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RoutingApp;
using RoutingApp.BookActivityOperations;
using RoutingApp.DummyResources;

namespace UnitTests.RoutingApp;

public class HandlerUnitTests
{
    private readonly Handler _handler;

    private static Fixture Fixture = new();
    private Mock<IRouterParameterFactory> _mockFactory = new();
    private Mock<IBookActivityRouter> _mockRouter = new();
    private Mock<IKeyedServiceProvider> _mockKeyedServiceProvider = new();

    public HandlerUnitTests()
    {
        _handler = new Handler(_mockFactory.Object, _mockRouter.Object,
            _mockKeyedServiceProvider.Object);
    }

    [Fact]
    public async Task TestTask()
    {
        var command = Fixture.Create<Command>();
        var parameters = new RouterParameters(IntegrationAction.Approved, null, new AddBookRequest(), null);

        _mockFactory.Setup(mock => mock.GetParameters(command)).ReturnsAsync(parameters);

        _mockRouter.Setup(mock => mock.GetOperation(parameters)).Returns(nameof(AddBookApproved));

        _mockKeyedServiceProvider
            .Setup(mock => mock.GetRequiredKeyedService(typeof(IBookActivityOperation), nameof(AddBookApproved)))
            .Returns(Mock.Of<IBookActivityOperation>());

        await _handler.UseHandler(command);
    }
}