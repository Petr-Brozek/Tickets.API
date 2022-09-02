using System.Text.Json;
using Tickets.Application.Enums;

namespace Tickets.Application.Models.Common;

public class Error
{
    public ErrorCode Code { get; }
    public string Message { get; }

    public Error(ErrorCode code, string message)
    {
        Code = code;
        Message = message;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
