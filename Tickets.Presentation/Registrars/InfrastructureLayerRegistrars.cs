using Tickets.Application.Mail;
using Tickets.Application.Notifications.Tickets.Mail;
using Tickets.Core.Abstractions;
using Tickets.Core.Abstractions.Repositories.CmdRepo;
using Tickets.Core.Abstractions.Repositories.QryRepo;
using Tickets.Infrastructure.Dal.Repositories.CmdRepos;
using Tickets.Infrastructure.Dal.Repositories.QryRepos;
using Tickets.Infrastructure.Services.MailService;

namespace Tickets.Presentation.Registrars;

public class InfrastructureLayerRegistrars : IWebApplicationBuilderRegistrar
{
   public void RegisterServices(WebApplicationBuilder builder)
   {
      // Repository
      builder.Services.AddScoped<ICommandRepositoryWrapper, CommandRepositoryWrapper>();
      builder.Services.AddScoped<IQueryRepositoryWrapper, QueryRepositoryWrapper>();

      // Mail
      var emailConfig = builder.Configuration
              .GetSection("EmailConfiguration")
              .Get<MailConfiguration>();
      builder.Services.AddSingleton(emailConfig);
      builder.Services.AddScoped<IMailSender, MailSender>();
      builder.Services.AddScoped<IMailService, MailService>();
      builder.Services.AddScoped<ITicketNotificationsMailContentMaker, TicketNotificationsMailContentMaker>();
   }
}
