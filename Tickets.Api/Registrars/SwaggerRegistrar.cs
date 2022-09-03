using Microsoft.OpenApi.Models;
using Tickets.Presentation.Options;

namespace Tickets.Presentation.Registrars;

public class SwaggerRegistrar : IWebApplicationBuilderRegistrar
{
   public void RegisterServices(WebApplicationBuilder builder)
   {
      builder.Services.AddSwaggerGen(c =>
      {
         c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
         {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
         });
         c.AddSecurityRequirement(new OpenApiSecurityRequirement {
           {
               new OpenApiSecurityScheme {
                   Reference = new OpenApiReference {
                       Type = ReferenceType.SecurityScheme,
                           Id = "Bearer"
                   }
               },
               new string[] {}
           }
         });
      });
      builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
   }
}
