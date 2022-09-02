using Tickets.Application.Enums;

namespace Tickets.Application.Models.Common;

public class OperationResult<T>
{
   public T? Payload { get; private set; }
   public bool IsError { get; private set; }
   public List<Error> Errors { get; private set; } = new List<Error>();

   public void SetPayload(T payload)
   {
      Payload = payload;
   }

   public void AddError(Error e)
   {
      IsError = true;
      Errors.Add(e);
   }

   public void AddErrors(IEnumerable<Error> errs)
   {
      IsError = true;
      Errors.AddRange(errs);
   }

   public void AddError(Exception e)
   {
      IsError = true;
      Errors.Add(new Error(code: ErrorCode.UnknownError, message: "exception: " + e.Message
         + ", innerException: " + (e.InnerException != null ? e.InnerException.Message : "")));
   }
}
