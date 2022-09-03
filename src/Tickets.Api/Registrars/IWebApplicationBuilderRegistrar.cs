namespace Tickets.Presentation.Registrars;

public interface IWebApplicationBuilderRegistrar : IRegistrar
{
   void RegisterServices(WebApplicationBuilder builder);
}
