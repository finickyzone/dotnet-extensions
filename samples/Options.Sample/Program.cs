using Finickyzone.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddServicesFromAssemblyOf<Program>();

WebApplication app = builder.Build();

app.Map("/", (HttpContext context, CancellationToken cancellationToken) =>
{
    const string html = $@"
<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
</head>
<body>
    <h1>Options</h1>
    <ul>
        <li>
            <a href=""/options"">Default</a>
        </li>
        <li>
            <a href=""/options/{MyOptions.Name1}"">{MyOptions.Name1}</a>
        </li>
        <li>
            <a href=""/options/{MyOptions.Name2}"">{MyOptions.Name2}</a>
        </li>
    </ul>
</body>
</html>
";
    context.Response.ContentType = "text/html; charset=utf-8";
    context.Response.StatusCode = StatusCodes.Status200OK;
    context.Response.WriteAsync(html, cancellationToken);
});
app.Map("options/{name?}", (string? name, IOptionsSnapshot<MyOptions> options) => options.Get(name));

app.Run();