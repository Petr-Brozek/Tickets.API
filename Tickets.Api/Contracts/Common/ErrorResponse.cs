namespace Tickets.Presentation.Contracts.Common;

public class ErrorResponse
{
   public ErrorResponse(int errorCode, string errorPhrase, string errorMessage)
   {
      ErrorCode = errorCode;
      ErrorPhrase = errorPhrase;
      ErrorMessage = errorMessage;
      TimeStamp = DateTime.Now;
   }

   public int ErrorCode { get; }
   public string ErrorPhrase { get; }
   public string ErrorMessage { get; }
   public DateTime TimeStamp { get; }
}
