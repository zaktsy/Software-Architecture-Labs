using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOcelot();

var app = builder.Build();

app.MapControllers();

await app.UseOcelot();

app.Run();