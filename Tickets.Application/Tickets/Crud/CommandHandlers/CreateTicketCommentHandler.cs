using MediatR;
using Tickets.Application.Enums;
using Tickets.Application.Models.Common;
using Tickets.Application.Tickets.Commands;
using Tickets.Core.Abstractions.Repositories.CmdRepo;
using Tickets.Core.Abstractions.Repositories.QryRepo;
using Tickets.Core.Aggregates.TicketAggregate;
using Tickets.Core.Aggregates.UserProfileAggregate;

namespace Tickets.Application.Tickets.CommandHandlers;

public class CreateTicketCommentHandler : IRequestHandler<CreateTicketComment, OperationResult<TicketComment>>
{
   private readonly IQueryRepositoryWrapper _qryRepo;
   private readonly ICommandRepositoryWrapper _cmdRepo;

   public CreateTicketCommentHandler(IQueryRepositoryWrapper qryRepo, ICommandRepositoryWrapper cmdRepo)
   {
      _qryRepo = qryRepo;
      _cmdRepo = cmdRepo;
   }

   public async Task<OperationResult<TicketComment>> Handle(CreateTicketComment request, CancellationToken cancellationToken)
   {
      var result = new OperationResult<TicketComment>();

      try
      {
         var ticket = _qryRepo.Ticket.GetTicketWithDetailsByIdAsync(request.TicketId);
         if (ticket is null)
         {
            result.AddError(new Error(code: ErrorCode.NotFound, message: $"Ticket not found"));
         }

         var createdByUserProfile = await _qryRepo.UserProfile.GetUserProfileWithDetailsByIdAsync(request.CreatedByUserProfileId);
         if (createdByUserProfile is null)
         {
            result.AddError(new Error(code: ErrorCode.NotFound, message: $"UserProfile (creator) not found"));
         }
         
         var commentToCreate = TicketComment.CreateTicketComment(
            request.TicketId,
            request.CreatedByUserProfileId,
            request.Content);

         _cmdRepo.TicketComment.Create(commentToCreate);
         await _cmdRepo.SaveAsync();

         result.SetPayload(commentToCreate);

         return result;
      }

      catch (Exception e)
      {
         result.AddError(e);

         return result;
      }
   }
}
