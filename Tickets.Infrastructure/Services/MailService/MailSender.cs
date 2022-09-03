using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;
using Tickets.Domain.Abstractions.Mail;
using Tickets.Domain.Models.Mail;

namespace Tickets.Infrastructure.Services.MailService;

public class MailSender : IMailSender
{
   private readonly ILogger<MailSender> _logger;
   private readonly MailConfiguration _emailConfig;

   public MailSender(ILogger<MailSender> logger, MailConfiguration emailConfig)
   {
      _emailConfig = emailConfig;
      _logger = logger;
   }

   public bool SendEmail(MailMessage message)
   {
      var emailMessage = CreateEmailMessage(message);

      return Send(emailMessage);
   }

   public async Task<bool> SendEmailAsync(MailMessage message)
   {
      var emailMessage = CreateEmailMessage(message);

      return await SendAsync(emailMessage);
   }

   private MimeMessage CreateEmailMessage(MailMessage message)
   {
      var emailMessage = new MimeMessage();
      emailMessage.From.Add(new MailboxAddress(_emailConfig.FromName, _emailConfig.From));
      emailMessage.To.AddRange(ConvertMessageAddress(message.To));
      emailMessage.Cc.AddRange(ConvertMessageAddress(message.Cc));
      emailMessage.Bcc.AddRange(ConvertMessageAddress(message.Bcc));
      emailMessage.Subject = message.Subject;
      emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Body };

      return emailMessage;
   }

   private bool Send(MimeMessage mailMessage)
   {
      bool sentOk = true;

      using var client = new SmtpClient();
      try
      {
         client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
         client.AuthenticationMechanisms.Remove("XOAUTH2");
         client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

         client.Send(mailMessage);
      }

      catch (Exception e)
      {
         sentOk = false;
         _logger.LogError($"Some error occured when sending email. Details: {e.Message} " +
             $"{(e.InnerException != null ? "|" + e.InnerException.Message : "")}");
      }

      finally
      {
         client.Disconnect(true);
         client.Dispose();
      }

      return sentOk;
   }

   private async Task<bool> SendAsync(MimeMessage mailMessage)
   {
      bool sentOk = true;

      using var client = new SmtpClient();
      try
      {
         await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
         client.AuthenticationMechanisms.Remove("XOAUTH2");
         await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
         await client.SendAsync(mailMessage);
      }

      catch (Exception e)
      {
         sentOk = false;
         _logger.LogError($"Some error occured when sending email. Details: {e.Message} " +
             $"{(e.InnerException != null ? "|" + e.InnerException.Message : "")}");
      }

      finally
      {
         await client.DisconnectAsync(true);
         client.Dispose();
      }

      return sentOk;
   }

   private static IEnumerable<MailboxAddress> ConvertMessageAddress(IEnumerable<MailAddress> mailAddress)
       => mailAddress.Select(ma => new MailboxAddress(ma.DisplayName, ma.Address));
}
