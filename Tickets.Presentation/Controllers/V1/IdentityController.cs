using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tickets.Presentation.Contracts.Identity.Requests;
using Tickets.Presentation.Definitions;
using Tickets.Presentation.Filters;

namespace Tickets.Presentation.Controllers.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
[ApiController]
[AllowAnonymous]
public class IdentityController : ApiBaseController
{
   private readonly IMapper _mapper;
   private readonly IMediator _mediator;

   public IdentityController(IMapper mapper, IMediator mediator, ILogger<ApiBaseController> logger)
     : base(logger)
   {
      _mapper = mapper;
      _mediator = mediator;
   }

   [HttpPost]
   [Route(ApiRoutes.Identity.Login)]
   [ValidateModel]
   public async Task<IActionResult> Login([FromBody] Login login)
   {
      var command = _mapper.Map<Application.Identity.Commands.Login>(login);
      var result = await _mediator.Send(command);

      if (result.IsError)
         return HandleErrorResonse(result.Errors);

      var response = _mapper.Map<Contracts.Identity.Responses.Login>(result.Payload);

      return Ok(response);
   }

   [HttpPost]
   [Route(ApiRoutes.Identity.Logout)]
   public async Task<IActionResult> Logout()
   {
      var result = await _mediator.Send(new Application.Identity.Commands.Logout());

      if (result.IsError)
         return HandleErrorResonse(result.Errors);

      return NoContent();
   }

   [HttpPost]
   [Route(ApiRoutes.Identity.Register)]
   [ValidateModel]
   public async Task<IActionResult> Register([FromBody] Register userToRegister)
   {
      var command = _mapper.Map<Application.Identity.Commands.Register>(userToRegister);
      var result = await _mediator.Send(command);

      if (result.IsError)
         return HandleErrorResonse(result.Errors);

      return NoContent();
   }
}
