using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Core.Aggregates.TicketAggregate;
using Tickets.Core.Enums.Ticket;

namespace Tickets.Infrastructure.Dal.Configurations;

public class TicketStateFlowConfig : IEntityTypeConfiguration<TicketStateFlow>
{
   public void Configure(EntityTypeBuilder<TicketStateFlow> builder)
   {
      builder.HasKey(sf => new { sf.OriginalStateName, sf.PossibleStateName });
      builder.HasOne(sf => sf.OriginalState).WithMany().HasForeignKey(sf => sf.OriginalStateName);
      builder.HasOne(sf => sf.PossibleState).WithMany().HasForeignKey(sf => sf.PossibleStateName);
      builder.Property(sf => sf.OriginalStateName)
        .HasConversion(
          s => s.ToString(),
          s => (TicketStateName)Enum.Parse(typeof(TicketStateName), s)
        );
      builder.Property(sf => sf.PossibleStateName)
        .HasConversion(
          s => s.ToString(),
          s => (TicketStateName)Enum.Parse(typeof(TicketStateName), s)
        );


      Seed(builder);
   }

   private static void Seed(EntityTypeBuilder<TicketStateFlow> builder)
   {
      builder.HasData(TicketStateFlow.CreateTicketStateFlow(TicketStateName.New, TicketStateName.Cancelled, "Cancel"));
      builder.HasData(TicketStateFlow.CreateTicketStateFlow(TicketStateName.New, TicketStateName.InProgress, "Start working"));
      builder.HasData(TicketStateFlow.CreateTicketStateFlow(TicketStateName.InProgress, TicketStateName.Finished, "Finish"));
      builder.HasData(TicketStateFlow.CreateTicketStateFlow(TicketStateName.InProgress, TicketStateName.Cancelled, "Cancel"));
      builder.HasData(TicketStateFlow.CreateTicketStateFlow(TicketStateName.Cancelled, TicketStateName.InProgress, "Re-open"));
      builder.HasData(TicketStateFlow.CreateTicketStateFlow(TicketStateName.Finished, TicketStateName.InProgress, "Re-open"));
   }
}
