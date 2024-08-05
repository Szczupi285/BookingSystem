using BookingSystem.Application.Commands;
using BookingSystem.Infrastructure.EF.DTO;
using BookingSystem.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookingSystem.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddLocation")]
        public async Task<IActionResult> AddLocation([FromBody] AddLocation request)
        {
            var command = new AddLocation(request.CityName, request.StreetName, request.HouseNumber, request.FlatNumber, request.PostalCode);
            await _mediator.Send(command);
            return Ok("Location added successfully");
        }
        [HttpPost("RemoveLocation")]
        public async Task<IActionResult> RemoveLocation([FromBody] RemoveLocation request)
        {
            var command = new RemoveLocation(request.LocationId);
            await _mediator.Send(command);
            return Ok("Location removed successfully");
        }
        [HttpPost("AddDesk")]
        public async Task<IActionResult> AddDesk([FromBody] AddDesk request)
        {
            var command = new AddDesk(request.LocationId, request.LocationCode);
            await _mediator.Send(command);
            return Ok("Desk added successfully");
        }
        [HttpPost("RemoveDesk")]
        public async Task<IActionResult> RemoveDesk([FromBody] RemoveDesk request)
        {
            var command = new RemoveDesk(request.LocationId, request.DeskId);
            await _mediator.Send(command);
            return Ok("Desk removed successfully");
        }
        [HttpPost("MakeDeskUnavailable")]
        public async Task<IActionResult> MakeDeskUnavailable([FromBody] MakeDeskUnavailable request)
        {
            var command = new MakeDeskUnavailable(request.LocationId, request.DeskId);
            await _mediator.Send(command);
            return Ok("Desk made unavailable successfully");
        }
        [HttpPost("MakeDeskAvailable")]
        public async Task<IActionResult> MakeDeskAvailable([FromBody] MakeDeskAvailable request)
        {
            var command = new MakeDeskAvailable(request.LocationId, request.DeskId);
            await _mediator.Send(command);
            return Ok("Desk made available successfully");
        }


    }
}
