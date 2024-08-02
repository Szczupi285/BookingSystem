using BookingSystem.Application.DTO;
using BookingSystem.Application.Services;
using BookingSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Queries.Handlers
{
    public class GetAllLocationsHandler : IRequestHandler<GetAllLocations, IEnumerable<LocationDTO>>
    {
        private readonly ILocationRepository _locationRepository;

        public GetAllLocationsHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<LocationDTO>> Handle(GetAllLocations request, CancellationToken cancellationToken)
        {
            var locations = await _locationRepository.GetAllAsync();
            return locations.Select(l => new LocationDTO
            (
                l.Id,
                l.CityName,
                l.StreetName,
                l.HouseNumber,
                l.FlatNumber,
                l.PostalCode
            ));
            
        }
    }
}
