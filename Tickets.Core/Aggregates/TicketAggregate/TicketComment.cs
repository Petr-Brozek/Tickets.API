using Tickets.Core.Exceptions;
using Tickets.Core.Validators;
using Tickets.Core.Validators.TicketValidators;

namespace Tickets.Core.Aggregates.TicketAggregate;

public class TicketComment : EntityBaseWithId<Guid>
{
    private TicketComment()
    {

    }

    public Guid TicketId { get; private set; }
    public Guid CreatedByUserProfileId { get; private set; }
    public string Content { get; private set; } = string.Empty;
    public DateTime CreatedDate { get; private set; }
    public DateTime LastModifiedDate { get; private set; }

    /// <summary>
    /// Creates a new TicketComment instance
    /// </summary>
    /// <param name="ticketId"></param>
    /// <param name="createdByUserProfileId"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    /// <exception cref="TicketCommentNotValidException"></exception>
    public static TicketComment CreateTicketComment(Guid ticketId, Guid createdByUserProfileId, string content)
    {
        var commentToCreate = new TicketComment
        {
            Id = Guid.NewGuid(),
            TicketId = ticketId,
            CreatedByUserProfileId = createdByUserProfileId,
            Content = content,
            CreatedDate = DateTime.Now,
            LastModifiedDate = DateTime.Now,
        };

        return ValidateTicketComment(commentToCreate);
    }

    public TicketComment UpdateContent(string newContent)
    {
        Content = newContent;
        LastModifiedDate = DateTime.Now;

        return ValidateTicketComment(this);
    }

    private static TicketComment ValidateTicketComment(TicketComment comment)
    {
        var validator = new Validator<TicketComment>(new TicketCommentValidator());

        return validator.Validate(comment);
    }
}
