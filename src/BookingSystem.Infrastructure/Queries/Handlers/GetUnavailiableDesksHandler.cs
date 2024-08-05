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
    internal sealed class GetUnavailiableDesksHandler : IRequestHandler<GetUnavailiableDesks, IEnumerable<UnavailableDeskDTO>>
    {
        private readonly AppDbContext _dbContext;
        public GetUnavailiableDesksHandler(AppDbContext context)
            => _dbContext = context;

        public async Task<IEnumerable<UnavailableDeskDTO>> Handle(GetUnavailiableDesks request, CancellationToken cancellationToken)
                => await _dbContext.Desks
                .Where(d => d.Location.Id == request.LocationId && 
                   d.Availability == false ||
                   d.Reservations.Any(r => d.Reservations.Any(r =>
                    request.StartDate <= r.EndDate && r.StartDate < request.EndDate)))
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(d => new UnavailableDeskDTO
                (
                    d.Id,
                    d.DeskLocationCode,
                    d.Location.Id
                )).ToListAsync(cancellationToken);

    }
}
