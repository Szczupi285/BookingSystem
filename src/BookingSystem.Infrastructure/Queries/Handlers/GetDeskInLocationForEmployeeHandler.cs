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
    public class GetDeskInLocationForEmployeeHandler : IRequestHandler<GetDeskInLocationForEmployee, DeskReservationDTO>
    {
        private readonly AppDbContext _dbContext;
        public GetDeskInLocationForEmployeeHandler(AppDbContext context)
            => _dbContext = context;

        public async Task<DeskReservationDTO> Handle(GetDeskInLocationForEmployee request, CancellationToken cancellationToken)
         => await _dbContext.Desks
            .Where(d => d.Location.Id == request.LocationId)
            .Select(d => new DeskReservationDTO
            (
                d.Id,
                d.DeskLocationCode,
                d.Location.Id,
                d.Availability,
                d.Reservations.Select(r => new ReservationDTO
                (
                    r.Id,
                    r.StartDate,
                    r.EndDate
                ))
            )).FirstAsync(cancellationToken);
    }
}
