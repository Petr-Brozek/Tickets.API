using MediatR;
using Tickets.Application.Enums;
using Tickets.Application.Models.Common;
using Tickets.Application.Tickets.Commands;
using Tickets.Core.Abstractions.Repositories.CmdRepo;
using Tickets.Core.Abstractions.Repositories.QryRepo;

namespace Tickets.Application.Tickets.CommandHandlers;

public class UpdateTicketCommentHandler : IRequestHandler<UpdateTicketComment, OperationResult<Unit>>
{
   private readonly IQueryRepositoryWrapper _qryRepo;
   private readonly ICommandRepositoryWrapper _cmdRepo;

   public UpdateTicketCommentHandler(IQueryRepositoryWrapper qryRepo, ICommandRepositoryWrapper cmdRepo)
   {
      _qryRepo = qryRepo;
      _cmdRepo = cmdRepo;
   }

   public async Task<OperationResult<Unit>> Handle(UpdateTicketComment request, CancellationToken cancellationToken)
   {
      var result = new OperationResult<Unit>();

      try
      {
         var commentToEdit = await _qryRepo.TicketComment.GetTicketCommentByIdAsync(request.TicketCommentId);
         if (commentToEdit is null)
         {
            result.AddError(new Error(code: ErrorCode.NotFound, message: "Ticket comment not found"));
            return result;
         }

         commentToEdit.UpdateContent(request.Content);
         _cmdRepo.TicketComment.Update(commentToEdit);
         await _cmdRepo.SaveAsync();

         return result;
      }

      catch (Exception e)
      {
         result.AddError(e);
         return result;
      }
   }
}
