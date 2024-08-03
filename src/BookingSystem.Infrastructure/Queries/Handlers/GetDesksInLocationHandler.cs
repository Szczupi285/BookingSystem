using BookingSystem.Application.DTO;
using BookingSystem.Application.Queries;
using BookingSystem.Infrastructure.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Queries.Handlers
{
    internal sealed class GetDesksInLocationHandler : IRequestHandler<GetDesksInLocation, IEnumerable<DeskDTO>>
    {
        private readonly AppDbContext _dbContext;
        public GetDesksInLocationHandler(AppDbContext context)
            => _dbContext = context;

        public async Task<IEnumerable<DeskDTO>> Handle(GetDesksInLocation request, CancellationToken cancellationToken)
            => await _dbContext.Locations
            .Where(l => l.Id == request.LocationId)
            .SelectMany(l => l.Desks)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(d => new DeskDTO
            (
                d.Id,
                d.DeskLocationCode,
                d.Location.Id,
                d.Availability
            )).ToListAsync(cancellationToken);
    }
}
