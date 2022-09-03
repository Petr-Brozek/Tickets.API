using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Domain.Aggregates.TicketAggregate;
using Tickets.Domain.Enums.Ticket;

namespace Tickets.Infrastructure.Dal.Configurations;

public class TicketStateConfig : IEntityTypeConfiguration<TicketState>
{
   public void Configure(EntityTypeBuilder<TicketState> builder)
   {
      builder.HasKey(ts => ts.Name);
      builder.Property(ts => ts.Name)
        .HasConversion(
          s => s.ToString(),
          s => (TicketStateName)Enum.Parse(typeof(TicketStateName), s)
        );

      Seed(builder);
   }
   private static void Seed(EntityTypeBuilder<TicketState> builder)
   {
      builder.HasData(TicketState.CreateNewTicketDefaultState());
      builder.HasData(TicketState.CreateTicketState(TicketStateName.InProgress, "In Progress"));
      builder.HasData(TicketState.CreateTicketState(TicketStateName.Finished, "Fnished"));
      builder.HasData(TicketState.CreateTicketState(TicketStateName.Cancelled, "Cancelled"));
   }
}
