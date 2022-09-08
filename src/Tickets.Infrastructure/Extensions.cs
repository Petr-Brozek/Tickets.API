using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tickets.Domain.Abstractions.Mail;
using Tickets.Domain.Abstractions.Repositories.CmdRepo;
using Tickets.Domain.Abstractions.Repositories.QryRepo;
using Tickets.Infrastructure.Dal;
using Tickets.Infrastructure.Dal.Repositories.CmdRepos;
using Tickets.Infrastructure.Dal.Repositories.QryRepos;
using Tickets.Infrastructure.Services.MailService;

namespace Tickets.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICommandRepositoryWrapper, CommandRepositoryWrapper>();
        services.AddScoped<IQueryRepositoryWrapper, QueryRepositoryWrapper>();
        
        var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
        var emailConfig = configuration
            .GetSection("EmailConfiguration")
            .Get<MailConfiguration>();
        services.AddSingleton(emailConfig);
        services.AddScoped<IMailSender, MailSender>();
        
        var cs = configuration.GetConnectionString("Default");
        services.AddDbContext<DataContext>(options => { options.UseSqlServer(cs); });

        return services;
    }
}