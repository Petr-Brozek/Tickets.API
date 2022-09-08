using Tickets.Application.Notifications.Tickets.Mail;
using Tickets.Domain.Abstractions.Mail;
using Tickets.Domain.Abstractions.Notifications.Tickets;
using Tickets.Domain.Abstractions.Repositories.CmdRepo;
using Tickets.Domain.Abstractions.Repositories.QryRepo;
using Tickets.Infrastructure.Dal.Repositories.CmdRepos;
using Tickets.Infrastructure.Dal.Repositories.QryRepos;
using Tickets.Infrastructure.Services.MailService;

namespace Tickets.Presentation.Registrars;

public class InfrastructureLayerRegistrars : IWebApplicationBuilderRegistrar
{
   public void RegisterServices(WebApplicationBuilder builder)
   {
      // // Repositoryz
      // builder.Services.AddScoped<ICommandRepositoryWrapper, CommandRepositoryWrapper>();
      // builder.Services.AddScoped<IQueryRepositoryWrapper, QueryRepositoryWrapper>();
      //
      // // Mail
      // var emailConfig = builder.Configuration
      //         .GetSection("EmailConfiguration")
      //         .Get<MailConfiguration>();
      // builder.Services.AddSingleton(emailConfig);
      // builder.Services.AddScoped<IMailSender, MailSender>();
      // builder.Services.AddScoped<ITicketNotificationsMailContentMaker, TicketNotificationsMailContentMaker>();
   }
}
