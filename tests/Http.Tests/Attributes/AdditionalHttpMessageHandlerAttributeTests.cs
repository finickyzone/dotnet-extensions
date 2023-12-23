using Finickyzone.Extensions.DependencyInjection;
using Finickyzone.Extensions.Http.Clients;
using Finickyzone.Extensions.Http.MessageHandlers;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Http;

public sealed class AdditionalHttpMessageHandlerAttributeTests
{
    [Fact]
    public void Client_WithDelegatingHandler_ShouldHaveMessageHandler()
    {
        // Arrange
        using ServiceProvider services = new ServiceCollection().AddServicesFromAssemblyOf<AdditionalHttpMessageHandlerAttributeTests>().BuildServiceProvider();

        // Act
        HttpClient client = services.GetRequiredService<Client_Typed_WithHttpMessageHandler>().Client;

        // Assert
        IEnumerable<HttpMessageHandler> handlers = client.GetHttpMessageHandlers();
        handlers.Should().Contain(handler => handler is FakeDelegatingHandler);
    }
}