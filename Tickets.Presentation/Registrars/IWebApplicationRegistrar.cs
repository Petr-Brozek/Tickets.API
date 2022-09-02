namespace Tickets.Presentation.Registrars;

public interface IWebApplicationRegistrar : IRegistrar
{
   void RegisterPipelineComponents(WebApplication app);
}
