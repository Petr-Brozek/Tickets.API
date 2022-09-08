using Tickets.Infrastructure;
using Tickets.Application;
using Tickets.Presentation.Extensions;
using Tickets.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices(typeof(Program));
builder.Services.AddInfrastructure();
builder.Services.AddApplication();

var app = builder.Build();

app.UseShared();
app.RegisterPipelineComponents(typeof(Program));

app.Run();
