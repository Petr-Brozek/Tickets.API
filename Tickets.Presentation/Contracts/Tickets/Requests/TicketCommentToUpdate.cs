using System.ComponentModel.DataAnnotations;

namespace Tickets.Presentation.Contracts.Tickets.Requests;

public class TicketCommentToUpdate
{
   [Required]
   [MaxLength(2000)]
   public string Content { get; set; } = string.Empty;
}
