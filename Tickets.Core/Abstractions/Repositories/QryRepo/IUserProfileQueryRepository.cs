using Tickets.Core.Aggregates.UserProfileAggregate;

namespace Tickets.Core.Abstractions.Repositories.QryRepo;

public interface IUserProfileQueryRepository : IQueryRespositoryBase<UserProfile>
{
    Task<IEnumerable<UserProfile>> GetAllUserProfilesAsync();
    Task<UserProfile> GetUserProfileWithDetailsByIdAsync(Guid userProfileId);
}
