using MediatR;
using Tickets.Application.Models.Common;
using Tickets.Domain.Models.Mail;

namespace Tickets.Application.Mail.Commands;

public record SendMail(MailMessage mailMessage) : IRequest<OperationResult<Unit>>;
