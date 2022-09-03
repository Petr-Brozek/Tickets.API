using MediatR;
using Tickets.Application.Models.Common;

namespace Tickets.Application.Identity.Commands;

public record Register() : IRequest<OperationResult<Unit>>
{
 public string EmailAddress { get; set; } = String.Empty;
 public string Password { get; set; } = String.Empty;
 public string FirstName { get; set; } = String.Empty;
 public string LastName { get; set; } = String.Empty;
}
