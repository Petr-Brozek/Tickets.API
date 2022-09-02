using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Core.Aggregates.UserProfileAggregate;

namespace Tickets.Infrastructure.Dal.Configurations;

public class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
{
 public void Configure(EntityTypeBuilder<UserProfile> builder)
 {
   builder.HasKey(up => up.UserProfileId);
   builder.OwnsOne(up => up.BasicInfo);
 }
}
