using Tickets.Api;
using Tickets.Infrastructure;
using Tickets.Application;
using Tickets.Presentation.Extensions;
using Tickets.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices(typeof(Program));
builder.Services.AddShared();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddApi();

var app = builder.Build();

app.UseShared();
app.RegisterPipelineComponents(typeof(Program));

app.Run();
