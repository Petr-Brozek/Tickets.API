namespace Tickets.Application.Enums;

public enum ErrorCode
{
   ValidationError = 101,
   Unauthorized = 401,
   NotFound = 404,
   ServerError = 500,
   ActionDenied = 601,
   UnknownError = 999,
}
