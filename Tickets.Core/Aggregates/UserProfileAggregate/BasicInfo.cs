using Tickets.Core.Exceptions;
using Tickets.Core.Validators;
using Tickets.Core.Validators.UserProfileValidators;

namespace Tickets.Core.Aggregates.UserProfileAggregate;

public class BasicInfo
{
 private BasicInfo()
 {
 }

 public string FirstName { get; private set; } = String.Empty;
 public string LastName { get; private set; } = String.Empty;
 public string EmailAddress { get; private set; } = String.Empty;

 /// <summary>
 /// Creates a new BasicInfo instance
 /// </summary>
 /// <param name="firstName"></param>
 /// <param name="lastName"></param>
 /// <param name="emailAddress"></param>
 /// <returns></returns>
 /// <exception cref="UserProfileNotValidException"></exception>
 public static BasicInfo CreateBasicInfo(string firstName, string lastName, string emailAddress)
 {
   var basicInfoToCreate = new BasicInfo()
   {
     FirstName = firstName,
     LastName = lastName,
     EmailAddress = emailAddress,
   };

   return ValidateBasicInfo(basicInfoToCreate);
 }

 private static BasicInfo ValidateBasicInfo(BasicInfo basicInfoToValidate)
 {
   var validator = new Validator<BasicInfo>(new BasicInfoValidator());

   return validator.Validate(basicInfoToValidate);
 }
}
