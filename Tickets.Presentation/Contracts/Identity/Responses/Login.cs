namespace Tickets.Presentation.Contracts.Identity.Responses;

public class Login
{
 public string Token { get; set; } = string.Empty;
 public DateTime ValidTo { get; set; }
}
