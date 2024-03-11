using Api.Extensions;
using ProjectS.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddArchitectures();
builder.AddServices();
builder.AddConsumers();

var app = builder.Build();
app.UseArchitectures();
app.MapEndpoints();
app.Run();