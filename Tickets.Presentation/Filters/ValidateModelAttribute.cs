using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tickets.Presentation.Contracts.Common;

namespace Tickets.Presentation.Filters;

public class ValidateModelAttribute : ActionFilterAttribute
{
   public override void OnActionExecuting(ActionExecutingContext context)
   {
      if (!context.ModelState.IsValid)
      {
         var error = new ErrorResponse(400, "Bad Request", "Model is not valid");
         
         context.Result = new BadRequestObjectResult(error);
      }
   }
}
