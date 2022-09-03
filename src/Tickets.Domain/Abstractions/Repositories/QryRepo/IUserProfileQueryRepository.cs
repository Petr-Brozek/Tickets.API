using Tickets.Domain.Aggregates.UserProfileAggregate;

namespace Tickets.Domain.Abstractions.Repositories.QryRepo;

public interface IUserProfileQueryRepository : IQueryRespositoryBase<UserProfile>
{
    Task<IEnumerable<UserProfile>> GetAllUserProfilesAsync();
    Task<UserProfile> GetUserProfileWithDetailsByIdAsync(Guid userProfileId);
}
