using Microsoft.Extensions.DependencyInjection;
using Tickets.Application.Notifications.Tickets.Mail;
using Tickets.Domain.Abstractions.Notifications.Tickets;

namespace Tickets.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ITicketNotificationsMailContentMaker, TicketNotificationsMailContentMaker>();
        return services;
    }
}