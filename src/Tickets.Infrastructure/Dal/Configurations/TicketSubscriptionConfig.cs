using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Domain.Aggregates.TicketAggregate;
using Tickets.Domain.Enums.Ticket;

namespace Tickets.Infrastructure.Dal.Configurations;
internal class TicketSubscriptionConfig : IEntityTypeConfiguration<TicketSubscription>
{
   public void Configure(EntityTypeBuilder<TicketSubscription> builder)
   {
      builder.HasKey(ts => ts.Id);
      builder.Property(ts => ts.DistrType)
        .HasConversion(
          s => s.ToString(),
          s => (TicketSubscriptionDistrType)Enum.Parse(typeof(TicketSubscriptionDistrType), s)
        );
      builder.Property(ts => ts.SubscriberRole)
        .HasConversion(
          s => s.ToString(),
          s => (TicketSubscriberRole)Enum.Parse(typeof(TicketSubscriberRole), s)
        );
      builder.Property(ts => ts.OnTicketAction)
        .HasConversion(
          s => s.ToString(),
          s => (TicketSubscriptionAction)Enum.Parse(typeof(TicketSubscriptionAction), s)
        );
   }
}
