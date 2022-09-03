using MediatR;
using Tickets.Application.Models.Common;

namespace Tickets.Application.Tickets.Commands;

public record UpdateTicketComment : IRequest<OperationResult<Unit>>
 {
     public Guid TicketId { get; set; }
     public Guid TicketCommentId { get; set; }
     public string Content { get; set; } = string.Empty;
 }
