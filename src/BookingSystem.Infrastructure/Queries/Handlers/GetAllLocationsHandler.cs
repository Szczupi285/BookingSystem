using BookingSystem.Application.DTO;
using BookingSystem.Application.Queries;
using BookingSystem.Infrastructure.EF;
using BookingSystem.Infrastructure.EF.Models;
using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Queries.Handlers
{
    internal sealed class GetAllLocationsHandler : IRequestHandler<GetAllLocations, IEnumerable<LocationDTO>>
    {
        private readonly AppDbContext _dbContext;

        public GetAllLocationsHandler(AppDbContext context)
            => _dbContext = context;

        public async Task<IEnumerable<LocationDTO>> Handle(GetAllLocations request, CancellationToken cancellationToken)
        {
            var count = await _dbContext.Locations.CountAsync();

            var locations = await _dbContext.Locations
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(l => new LocationDTO
                (
                    l.Id,
                    l.City,
                    l.Street,
                    l.HouseNumber,
                    l.FlatNumber,
                    l.PostalCode
                )).ToListAsync(cancellationToken);

            return locations;

        }
           
    }
}
