using AutoMapper;
using Tickets.Application.Tickets.Commands;
using Tickets.Core.Aggregates.TicketAggregate;
using Tickets.Presentation.Contracts.Tickets.Requests;
using Tickets.Presentation.Contracts.Tickets.Responses;

namespace Tickets.Presentation.MappingProfiles;

public class TicketMapping : Profile
{
   public TicketMapping()
   {
      CreateMap<Ticket, TicketResponse>();
      CreateMap<TicketToCreate, CreateTicket>();
      CreateMap<TicketCommentToCreate, CreateTicketComment>();
      CreateMap<TicketComment, TicketCommentResponse>();
      CreateMap<TicketCommentToUpdate, UpdateTicketComment>();
   }
}
