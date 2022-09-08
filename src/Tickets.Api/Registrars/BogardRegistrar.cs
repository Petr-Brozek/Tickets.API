using MediatR;
using Serilog;
using Tickets.Application.Tickets.Crud.Queries;

namespace Tickets.Presentation.Registrars;

public class BogardRegistrar : IWebApplicationBuilderRegistrar
{
   public void RegisterServices(WebApplicationBuilder builder)
   {
      var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .CreateLogger();
      builder.Logging.ClearProviders();
      builder.Logging.AddSerilog(logger);

      builder.Services.AddMediatR(typeof(GetAllTickets));
      builder.Services.AddAutoMapper(typeof(Program), typeof(GetAllTickets));
   }
}
