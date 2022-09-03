namespace Tickets.Presentation.Contracts.Tickets.Responses;

public class TicketResponse
{
   public Guid Id { get; set; }
   public string Summary { get; set; } = String.Empty;
   public string State { get; set; } = String.Empty;
   public DateTime CreatedDate { get; set; }
   public DateTime LastModifiedDate { get; set; }
   public Guid CreatedByUserProfileId { get; set; }
   public IList<TicketCommentResponse>? Comments { get; set; }
}
