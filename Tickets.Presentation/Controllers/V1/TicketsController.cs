using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tickets.Application.Definitions.Identity;
using Tickets.Application.Tickets.Commands;
using Tickets.Application.Tickets.Crud.Queries;
using Tickets.Presentation.Contracts.Tickets.Requests;
using Tickets.Presentation.Contracts.Tickets.Responses;
using Tickets.Presentation.Definitions;
using Tickets.Presentation.Filters;

namespace Tickets.Presentation.Controllers.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
[ApiController]
[Authorize]
public class TicketsController : ApiBaseController
{
   private readonly IMapper _mapper;
   private readonly IMediator _mediator;

   public TicketsController(ILogger<ApiBaseController> logger, IMapper mapper, IMediator mediator) : base(logger)
   {
      _mapper = mapper;
      _mediator = mediator;
   }

   [HttpGet]
   public async Task<IActionResult> GetAllTickets()
   {
      var result = await _mediator.Send(new GetAllTickets());

      if (result.HasErrors)
         return HandleErrorResonse(result.Errors);

      var ticketsResponse = _mapper.Map<IEnumerable<TicketResponse>>(result.Payload);

      return Ok(ticketsResponse);
   }

   [HttpGet]
   [Route(ApiRoutes.Tickets.IdRoute, Name = "GetTicketById")]
   [ValidateGuid("id")]
   public async Task<IActionResult> GetTicketById(string id)
   {
      var command = new GetTicketById(Guid.Parse(id));
      var result = await _mediator.Send(command);

      if (result.HasErrors)
         return HandleErrorResonse(result.Errors);

      var ticketResponse = _mapper.Map<TicketResponse>(result.Payload);

      return Ok(ticketResponse);
   }

   [HttpPost]
   [ValidateModel]
   [Authorize(Roles = UserRoles.CanCreateTicket)]
   public async Task<IActionResult> CreateTicket([FromBody] TicketToCreate newTicket)
   {
      var command = _mapper.Map<CreateTicket>(newTicket);
      var result = await _mediator.Send(command);

      if (result.HasErrors)
         return HandleErrorResonse(result.Errors);

      var ticketResponse = _mapper.Map<TicketResponse>(result.Payload);

      return CreatedAtAction("GetTicketById", new { id = ticketResponse.Id }, ticketResponse);
   }

   [HttpPost]
   [Route(ApiRoutes.Tickets.Comments.Base)]
   [Authorize(Roles = UserRoles.CanCreateTicketComment)]
   [ValidateGuid("ticketId")]
   public async Task<IActionResult> AddTicketComment(string ticketId, [FromBody] TicketCommentToCreate newComment)
   {
      var command = _mapper.Map<CreateTicketComment>(newComment);
      command.TicketId = Guid.Parse(ticketId);

      var result = await _mediator.Send(command);

      if (result.HasErrors)
         return HandleErrorResonse(result.Errors);

      var ticketCommentResponse = _mapper.Map<TicketCommentResponse>(result.Payload);

      return Ok(ticketCommentResponse);
   }

   [HttpPatch]
   [Route(ApiRoutes.Tickets.Comments.IdRoute)]
   [ValidateGuid("ticketId")]
   [ValidateGuid("id")]
   public async Task<IActionResult> EditTicketComment(string ticketId, string id,
     [FromBody] TicketCommentToUpdate newComment)
   {
      var command = _mapper.Map<UpdateTicketComment>(newComment);
      command.TicketId = Guid.Parse(ticketId);
      command.TicketCommentId = Guid.Parse(id);

      var result = await _mediator.Send(command);

      if (result.HasErrors)
         return HandleErrorResonse(result.Errors);

      return NoContent();
   }

   [HttpPatch]
   [Route(ApiRoutes.Tickets.State)]
   [ValidateGuid("id")]
   public async Task<IActionResult> ChangeTicketState(string id, [FromBody] TicketStateToUpdate stateToUpdate)
   {
      var command = new ChangeTicketState(Guid.Parse(id), stateToUpdate.NewStateName);
      var result = await _mediator.Send(command);

      if (result.HasErrors)
         return HandleErrorResonse(result.Errors);

      return NoContent();
   }

   [HttpPost]
   [Route(ApiRoutes.Tickets.Subscriptions.Base)]
   [ValidateGuid("ticketId")]
   public async Task<IActionResult> CreateTicketSubscription(string ticketId, TicketSubscriptionToCreate newSubscription)
   {
      throw new NotImplementedException();
   }
}
