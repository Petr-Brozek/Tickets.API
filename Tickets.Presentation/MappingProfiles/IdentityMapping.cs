using AutoMapper;

namespace Tickets.Presentation.MappingProfiles;

public class IdentityMapping : Profile
{
 public IdentityMapping()
 {
   CreateMap<Contracts.Identity.Requests.Login, Application.Identity.Commands.Login>();
   CreateMap<Contracts.Identity.Requests.Register, Application.Identity.Commands.Register>();
   CreateMap<Application.Models.Identity.GeneratedJwtToken, Contracts.Identity.Responses.Login>();
 }
}
