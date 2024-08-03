using BookingSystem.Application.DTO;
using BookingSystem.Application.Queries;
using BookingSystem.Infrastructure.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Queries.Handlers
{
    internal sealed class GetDeskInLocationForAdminHandler : IRequestHandler<GetDeskInLocationForAdmin, DetailedDeskDTO>
    {
        private readonly AppDbContext _dbContext;
        public GetDeskInLocationForAdminHandler(AppDbContext context)
            => _dbContext = context;

        public async Task<DetailedDeskDTO?> Handle(GetDeskInLocationForAdmin request, CancellationToken cancellationToken)
            => await _dbContext.Desks
            .Where(d => d.Location.Id == request.LocationId)
            .Select(d => new DetailedDeskDTO
            (
                d.Id,
                d.Location.Id,
                d.DeskLocationCode,
                d.Availability,
                d.Reservations.Select(r => new DetailedReservationDTO
                (
                    r.Id,
                    r.User.Id,
                    r.User.UserName,
                    r.User.Email,
                    r.StartDate,
                    r.EndDate
                ))
            )).FirstOrDefaultAsync(cancellationToken);
           
            
    }
}
