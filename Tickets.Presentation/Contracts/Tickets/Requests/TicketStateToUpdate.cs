using System.ComponentModel.DataAnnotations;

namespace Tickets.Presentation.Contracts.Tickets.Requests;

public class TicketStateToUpdate
{
   [Required]
   public string NewStateName { get; set; } = string.Empty;
}
