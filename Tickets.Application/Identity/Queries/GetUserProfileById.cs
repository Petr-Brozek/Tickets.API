using MediatR;
using Tickets.Application.Models.Common;
using Tickets.Core.Aggregates.UserProfileAggregate;

namespace Tickets.Application.Identity.Queries;

public record GetUserProfileById(Guid Id) : IRequest<OperationResult<UserProfile>>;
