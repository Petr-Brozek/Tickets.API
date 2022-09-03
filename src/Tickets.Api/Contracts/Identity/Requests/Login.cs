using System.ComponentModel.DataAnnotations;

namespace Tickets.Presentation.Contracts.Identity.Requests;

public class Login
{
 [Required]
 [EmailAddress]
 public string UserName { get; set; } = string.Empty;

 [Required]
 [DataType(DataType.Password)]
 public string Password { get; set; } = string.Empty;

 public bool RememberMe { get; set; } = false;
}
