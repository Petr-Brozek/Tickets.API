using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Tickets.Application.Models.Common;
using Tickets.Presentation.Contracts.Common;

namespace Tickets.Presentation.Controllers.V1;

public class ApiBaseController : ControllerBase
{
   protected readonly ILogger<ApiBaseController> _logger;

   public ApiBaseController(ILogger<ApiBaseController> logger)
   {
      _logger = logger;
   }

   protected IActionResult HandleErrorResonse(List<Error> errors)
   {
      if (errors.Any(e => e.Code == Application.Enums.ErrorCode.Unauthorized))
      {
         var error = errors.FirstOrDefault(e => e.Code == Application.Enums.ErrorCode.Unauthorized);
         var errorResponse = new ErrorResponse(401, "UnAuthorized", error!.ToString());
         MakeLog(errorResponse);

         return Unauthorized(errorResponse);
      }

      else if (errors.Any(e => e.Code == Application.Enums.ErrorCode.ActionDenied))
      {
         var error = errors.FirstOrDefault(e => e.Code == Application.Enums.ErrorCode.ActionDenied);
         var errorResponse = new ErrorResponse(401, "UnAuthorized", error!.ToString());
         MakeLog(errorResponse);

         return Unauthorized(errorResponse);
      }

      else if (errors.Any(e => e.Code == Application.Enums.ErrorCode.NotFound))
      {
         var error = errors.FirstOrDefault(e => e.Code == Application.Enums.ErrorCode.NotFound);
         var errorResponse = new ErrorResponse(401, "Not Found", error!.ToString());
         MakeLog(errorResponse);

         return NotFound(errorResponse);
      }

      else if (errors.Any(e => e.Code == Application.Enums.ErrorCode.ValidationError))
      {
         var error = errors.FirstOrDefault(e => e.Code == Application.Enums.ErrorCode.ValidationError);
         var errorResponse = new ErrorResponse(400, "Bad Request", error!.ToString());
         MakeLog(errorResponse);

         return Unauthorized(errorResponse);
      }

      var generalErrorResponse = new ErrorResponse(500, "Internal Server Error",
         String.Join("|", errors.Select(e => e.ToString())));
      MakeLog(generalErrorResponse);

      return StatusCode(500, generalErrorResponse);
   }

   private void MakeLog(ErrorResponse error)
      => _logger.LogWarning($"API error occured. Detail: {JsonSerializer.Serialize(error)}");
}
