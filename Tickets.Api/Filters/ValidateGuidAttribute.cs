using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tickets.Presentation.Contracts.Common;

namespace Tickets.Presentation.Filters;

public class ValidateGuidAttribute : ActionFilterAttribute
{
   private readonly string _key;

   public ValidateGuidAttribute(string key)
   {
      _key = key;
   }

   public override void OnActionExecuting(ActionExecutingContext context)
   {
      if (!context.ActionArguments.TryGetValue(_key, out var value))
         return;
      if (Guid.TryParse(value?.ToString(), out _))
         return;

      var error = new ErrorResponse(400, "Bad Request", $"Parametr {value} is not a valid Guid");
      
      context.Result = new BadRequestObjectResult(error);
   }
}
