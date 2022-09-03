﻿namespace Tickets.Presentation.Registrars;

public class MvcWebAppRegistrar : IWebApplicationRegistrar
{
   public void RegisterPipelineComponents(WebApplication app)
   {
      app.UseHttpsRedirection();

      app.UseAuthentication();
      app.UseAuthorization();

      app.MapControllers();
   }
}
