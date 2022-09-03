using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tickets.Domain.Aggregates.TicketAggregate;
using Tickets.Domain.Aggregates.UserProfileAggregate;
using Tickets.Infrastructure.Dal.Configurations;

namespace Tickets.Infrastructure.Dal;

public class DataContext : IdentityDbContext<IdentityUser>
{
   public DataContext(DbContextOptions options) : base(options)
   {
   }

   public DbSet<UserProfile> UserProfiles { get; set; }
   public DbSet<Ticket> Tickets { get; set; }
   public DbSet<TicketComment> TicketComments { get; set; }
   public DbSet<TicketState> TicketStates { get; set; }
   public DbSet<TicketStateFlow> TicketStateFlows { get; set; }
   public DbSet<TicketSubscription> TicketSubscriptions { get; set; }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      optionsBuilder.EnableSensitiveDataLogging();
   }

   protected override void OnModelCreating(ModelBuilder builder)
   {
      base.OnModelCreating(builder);

      builder.ApplyConfiguration(new UserProfileConfig());
      builder.ApplyConfiguration(new TicketConfig());
      builder.ApplyConfiguration(new TicketStateConfig());
      builder.ApplyConfiguration(new TicketStateFlowConfig());
      builder.ApplyConfiguration(new TicketSubscriptionConfig());
   }
}
