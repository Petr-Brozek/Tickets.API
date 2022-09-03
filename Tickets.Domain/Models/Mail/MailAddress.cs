namespace Tickets.Domain.Models.Mail;

public class MailAddress
{
   public string DisplayName { get; }
   public string Address { get; }

   public MailAddress(string displayName, string address)
   {
      DisplayName = displayName;
      Address = address;
   }
}
