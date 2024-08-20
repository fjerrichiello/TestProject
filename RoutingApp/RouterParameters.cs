using RoutingApp.DummyResources;

namespace RoutingApp;

public record RouterParameters(
    IntegrationAction Action,
    Book? Book,
    AddBookRequest? AddBookRequest,
    EditBookRequest? EditBookRequest
);