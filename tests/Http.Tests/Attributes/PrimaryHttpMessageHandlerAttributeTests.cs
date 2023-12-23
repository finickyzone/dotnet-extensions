using Finickyzone.Extensions.DependencyInjection;
using Finickyzone.Extensions.Http.Clients;
using Finickyzone.Extensions.Http.MessageHandlers;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Http;

public sealed class PrimaryHttpMessageHandlerAttributeTests
{
    [Fact]
    public void Client_WithPrimaryHttpMessageHandler_ShouldHaveMessageHandler()
    {
        // Arrange
        using ServiceProvider services = new ServiceCollection().AddServicesFromAssemblyOf<AdditionalHttpMessageHandlerAttributeTests>().BuildServiceProvider();

        // Act
        HttpClient client = services.GetRequiredService<Client_Typed_WithPrimaryHttpMessageHandler>().Client;

        // Assert
        IEnumerable<HttpMessageHandler> handlers = client.GetHttpMessageHandlers();
        handlers.Last().Should().BeOfType<FakeHttpMessageHandler>();
    }
}