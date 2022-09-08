using Tickets.Presentation.Extensions;
using Tickets.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices(typeof(Program));

var app = builder.Build();

app.UseShared();
app.RegisterPipelineComponents(typeof(Program));

app.Run();
