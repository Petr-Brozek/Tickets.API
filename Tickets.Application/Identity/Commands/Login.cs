using MediatR;
using Tickets.Application.Models.Common;
using Tickets.Application.Models.Identity;

namespace Tickets.Application.Identity.Commands;

public record Login(string UserName, string Password, bool RememberMe)
 : IRequest<OperationResult<GeneratedJwtToken>>;
