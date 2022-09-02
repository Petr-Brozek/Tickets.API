namespace Tickets.Core.Aggregates.UserProfileAggregate;

public class UserProfile
{
 private UserProfile()
 {
 }

 public Guid UserProfileId { get; private set; }
 public string IdentityId { get; private set; } = string.Empty;
 public BasicInfo BasicInfo { get; private set; }
 public DateTime CretedDate { get; private set; }
 public DateTime LastModifiedDate { get; private set; }


 /// <summary>
 /// Creates a new UserProfile instance
 /// </summary>
 /// <param name="identityId"></param>
 /// <param name="basicInfo"></param>
 /// <returns></returns>
 public static UserProfile CreateUserProfile(string identityId, BasicInfo basicInfo)
   => new()
   {
     UserProfileId = Guid.NewGuid(),
     IdentityId = identityId,
     BasicInfo = basicInfo,
     CretedDate = DateTime.Now,
     LastModifiedDate = DateTime.Now,
   };

 /// <summary>
 /// Updates a BasicInfo of existing UserProfile instance
 /// </summary>
 /// <param name="basicInfo"></param>
 public void UpdateBasicInfo(BasicInfo basicInfo)
 {
   BasicInfo = basicInfo;
   LastModifiedDate = DateTime.Now;
 }
}
