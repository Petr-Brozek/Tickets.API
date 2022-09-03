using System.ComponentModel.DataAnnotations;

namespace Tickets.Presentation.Contracts.Tickets.Requests;

public class TicketToCreate
{
 [Required]
 [StringLength(200)]
 public string Summary { get; set; } = String.Empty;

 [Required]
 public Guid CreatedByUserProfileId { get; set; }
}
