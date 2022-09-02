namespace Tickets.Presentation.Definitions;

public static class ApiRoutes
{
   public const string BaseRoute = "api/v{version:apiVersion}/[controller]";

   public static class Tickets
   {
      public const string IdRoute = "{id}";
      public const string State = "{id}/state";

      public static class Comments
      {
         public const string Base = "{ticketId}/comments";
         public const string IdRoute = "{ticketId}/comments/{id}";
      }

      public static class Subscriptions
      {
         public const string Base = "{ticketId}/subscriptions";
      }
   }

   public static class Identity
   {
      public const string Login = "login";
      public const string Logout = "logout";
      public const string Register = "register";
   }
}
