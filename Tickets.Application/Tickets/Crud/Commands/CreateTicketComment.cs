using MediatR;
using Tickets.Application.Models.Common;
using Tickets.Domain.Aggregates.TicketAggregate;

namespace Tickets.Application.Tickets.Commands;

public record CreateTicketComment : IRequest<OperationResult<TicketComment>>
 {
     public Guid TicketId { get; set; }
     public Guid CreatedByUserProfileId { get; set; }
     public string Content { get; set; } = string.Empty;
 }
