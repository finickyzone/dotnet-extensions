using Bogus;
using Finickyzone.Extensions.DependencyInjection;
using Finickyzone.Extensions.Http.Clients;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Http;

public sealed class HttpClientAttributeTests : IDisposable
{
    private static readonly Faker Faker = new();

    private static readonly string RootBaseAddress = Faker.Internet.Url();
    private static readonly string SectionBaseAddress = Faker.Internet.Url();

    private static readonly KeyValuePair<string, string?>[] ConfigurationData =
    [
        new("BaseAddress", RootBaseAddress),
        new($"{Client_Typed_WithConfigSection.ConfigSection}:BaseAddress", SectionBaseAddress)
    ];

    private readonly ServiceProvider _services;

    public HttpClientAttributeTests()
    {
        IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(ConfigurationData).Build();
        _services = new ServiceCollection().AddSingleton(configuration).AddServicesFromAssemblyOf<HttpClientAttributeTests>().BuildServiceProvider();
    }

    [Fact]
    public void Client_WithoutConfigSection_ShouldNotBindConfiguration()
    {
        // Act
        HttpClient client = _services.GetRequiredService<Client_Typed_WithConfigSection>().Client;

        // Assert
        client.BaseAddress.Should().Be(SectionBaseAddress);
    }

    [Fact]
    public void Client_WithConfigSection_ShouldBindConfiguration()
    {
        // Act
        HttpClient client = _services.GetRequiredService<Client_Typed_WithConfigSection>().Client;

        // Assert
        client.BaseAddress.Should().Be(SectionBaseAddress);
    }

    [Fact]
    public void Client_WithRootConfigSection_ShouldBindConfiguration()
    {
        HttpClient client = _services.GetRequiredService<Client_Typed_WithRootConfigSection>().Client;

        // Assert
        client.BaseAddress.Should().Be(RootBaseAddress);
    }

    public void Dispose() => _services.Dispose();
}