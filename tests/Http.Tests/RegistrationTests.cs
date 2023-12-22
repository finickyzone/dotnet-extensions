using Finickyzone.Extensions.DependencyInjection;
using Finickyzone.Extensions.Http.Clients;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Http;

public sealed class RegistrationTests
{
    [Fact]
    public void AddClientFromAssembly_WithCurrentAssembly_ShouldCreateClients()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        using ServiceProvider provider = services.AddServicesFromAssemblyOf<RegistrationTests>().BuildServiceProvider();

        // Assert
        provider.GetService<Client_Named>().Should().NotBeNull();
        provider.GetService<Client_Named_WithFactory>().Should().NotBeNull();
        provider.GetService<Client_Typed>().Should().NotBeNull();
    }
}