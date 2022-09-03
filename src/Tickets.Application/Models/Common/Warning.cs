using System.Text.Json;

namespace Tickets.Application.Models.Common;
public class Warning
{
   public string Message { get; }

   public Warning(string message)
   {
      Message = message;
   }

   public override string ToString()
   {
      return JsonSerializer.Serialize(this);
   }
}
