using System.ComponentModel.DataAnnotations;

namespace Tickets.Presentation.Contracts.Identity.Requests;

public class Register
{
 [Required]
 [EmailAddress]
 public string EmailAddress { get; set; } = String.Empty;

 [Required]
 public string Password { get; set; } = String.Empty;

 [Required]
 public string FirstName { get; set; } = String.Empty;

 [Required]
 public string LastName { get; set; } = String.Empty;
}
