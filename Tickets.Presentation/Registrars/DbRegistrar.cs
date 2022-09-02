using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tickets.Infrastructure.Dal;

namespace Tickets.Presentation.Registrars;

public class DbRegistrar : IWebApplicationBuilderRegistrar
{
   public void RegisterServices(WebApplicationBuilder builder)
   {
      var cs = builder.Configuration.GetConnectionString("Default");
      builder.Services.AddDbContext<DataContext>(options => { options.UseSqlServer(cs); });

      builder.Services.AddIdentity<IdentityUser, IdentityRole>()
          .AddEntityFrameworkStores<DataContext>()
          .AddDefaultTokenProviders();
   }
}
