using MediatR;
using Tickets.Application.Models.Common;

namespace Tickets.Application.Identity.Commands;

public record Logout : IRequest<OperationResult<Unit>>;
