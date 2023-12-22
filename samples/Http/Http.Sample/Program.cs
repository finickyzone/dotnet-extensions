using Finickyzone.Extensions.DependencyInjection;
using Finickyzone.Extensions.Samples.Clients;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServicesFromAssemblyOf<Program>();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();

var catFactClient = app.Services.GetRequiredService<CatFactClient>();
string? fact = await catFactClient.GetCatFact();

logger.LogInformation("Here's a cat fact: \"{Fact}\"", fact);

var boredClient = app.Services.GetRequiredService<BoredClient>();
string? activity = await boredClient.GetActivity();
logger.LogInformation("If you are bored, here's an activity to do: \"{Activity}\"", activity);