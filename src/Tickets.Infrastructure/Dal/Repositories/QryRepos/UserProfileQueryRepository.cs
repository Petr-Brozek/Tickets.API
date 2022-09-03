using Microsoft.EntityFrameworkCore;
using Tickets.Domain.Abstractions.Repositories.QryRepo;
using Tickets.Domain.Aggregates.UserProfileAggregate;

namespace Tickets.Infrastructure.Dal.Repositories.QryRepos;

public class UserProfileQueryRepository : QueryRepositoryBase<UserProfile>, IUserProfileQueryRepository
{
    public UserProfileQueryRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public async Task<IEnumerable<UserProfile>> GetAllUserProfilesAsync()
       => await FindAll()
          .ToListAsync();

    public async Task<UserProfile> GetUserProfileWithDetailsByIdAsync(Guid userProfileId)
       => await FindByCondition(up => up.UserProfileId.Equals(userProfileId))
          .Include(up => up.BasicInfo)
          .FirstOrDefaultAsync();
}
