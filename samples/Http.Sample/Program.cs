using Finickyzone.Extensions.DependencyInjection;
using Finickyzone.Extensions.Samples.Clients;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddServicesFromAssemblyOf<Program>();

IHost host = builder.Build();

var logger = host.Services.GetRequiredService<ILogger<Program>>();

var catFactClient = host.Services.GetRequiredService<CatFactClient>();
string? fact = await catFactClient.GetCatFact();

logger.LogInformation("Here's a cat fact: \"{Fact}\"", fact);

var boredClient = host.Services.GetRequiredService<BoredClient>();
string? activity = await boredClient.GetActivity();
logger.LogInformation("If you are bored, here's an activity to do: \"{Activity}\"", activity);