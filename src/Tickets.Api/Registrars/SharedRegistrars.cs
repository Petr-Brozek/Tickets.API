using Tickets.Presentation.Registrars;
using Tickets.Shared.Exceptions;

namespace Tickets.Api.Registrars;

public class SharedRegistrars : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ExceptionMiddleware>();
    }
}