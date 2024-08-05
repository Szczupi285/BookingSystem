using BookingSystem.Application.Commands;
using BookingSystem.Application.DTO;
using BookingSystem.Application.Queries;
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

        [HttpPost("ChangeReservedDesk")]
        public async Task<IActionResult> ChangeReserveDesk([FromBody] ChangeReservedDeskRequestDTO request)
        {
            var claims = User.Claims.ToDictionary(c => c.Type, c => c.Value);
            var userId = claims.GetValueOrDefault(ClaimTypes.NameIdentifier);

            var command = new ChangeReservedDesk(request.LocationId,request.OldDeskId, request.NewDeskId, Guid.Parse(userId), request.ReservationId);
            await _mediator.Send(command);
            return Ok("Desk reserved succesfully");
        }
        [HttpGet("GetAllLocations")]
        public async Task<ActionResult<IEnumerable<LocationDTO>>> GetAllLocations([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetAllLocations(pageNumber, pageSize);
            var locations = await _mediator.Send(query);
            return Ok(locations);
        }
        [HttpGet("GetDesksInLocation")]
        public async Task<ActionResult<IEnumerable<DeskDTO>>> GetDesksInLocation([FromQuery] Guid locationId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetDesksInLocation(locationId, pageNumber, pageSize);
            var locations = await _mediator.Send(query);
            return Ok(locations);
        }
        [HttpGet("GetDesksInLocationForEmployeeHandler")]
        public async Task<ActionResult<IEnumerable<DeskReservationDTO>>> GetDeskInLocationForEmployee([FromQuery] Guid locationId, Guid deskId)
        {
            var query = new GetDeskInLocationForEmployee(locationId, deskId);
            var locations = await _mediator.Send(query);
            return Ok(locations);
        }
        [HttpGet("GetAvailableDesks")]
        public async Task<ActionResult<IEnumerable<DeskReservationDTO>>> GetDeskInLocationForEmployee([FromQuery] Guid locationId, Guid deskId)
        {
            var query = new GetDeskInLocationForEmployee(locationId, deskId);
            var locations = await _mediator.Send(query);
            return Ok(locations);
        }

    }
}
