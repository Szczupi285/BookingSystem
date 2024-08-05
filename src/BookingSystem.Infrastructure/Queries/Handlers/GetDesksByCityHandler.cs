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
    internal sealed class GetDesksByCityHandler : IRequestHandler<GetDesksByCity, IEnumerable<DeskDTO>>
    {
        private readonly AppDbContext _dbContext;
        public GetDesksByCityHandler(AppDbContext context)
            => _dbContext = context;

        public async Task<IEnumerable<DeskDTO>> Handle(GetDesksByCity request, CancellationToken cancellationToken)
          => await _dbContext.Locations
            .Where(l => l.City.ToLower() == request.City.ToLower())
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

