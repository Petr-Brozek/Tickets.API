using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Core.Aggregates.TicketAggregate;

namespace Tickets.Infrastructure.Dal.Configurations;

public class TicketConfig : IEntityTypeConfiguration<TicketComment>
{
   public void Configure(EntityTypeBuilder<TicketComment> builder)
   {
      builder.HasKey(t => t.Id);
   }
}
