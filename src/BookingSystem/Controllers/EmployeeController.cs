using BookingSystem.Application.Commands;
using BookingSystem.Application.DTO;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingSystem.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Employee")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("ReserveDesk")]
        public async Task<IActionResult> ReserveDesk([FromBody] ReserveDeskRequestDTO request)
        {
            var claims = User.Claims.ToDictionary(c => c.Type, c => c.Value);
            var userId = claims.GetValueOrDefault(ClaimTypes.NameIdentifier);

            var command = new ReserveDesk(request.LocationId, request.DeskId, Guid.Parse(userId), request.startDate, request.numOfDays);
            await _mediator.Send(command);
            return Ok("Desk reserved succesfully");
        }

    }
}
