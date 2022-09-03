namespace Tickets.Presentation.Contracts.Tickets.Responses;

public class TicketCommentResponse
{
 public Guid Id { get; set; }
 public Guid CreatedByUserProfileId { get; set; }
 public string Content { get; set; } = string.Empty;
 public DateTime CreatedDate { get; set; }
 public DateTime LastModifiedDate { get; set; }
}
