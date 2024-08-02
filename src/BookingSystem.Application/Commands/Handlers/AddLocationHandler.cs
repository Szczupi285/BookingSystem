using BookingSystem.Domain.Entities;
using BookingSystem.Domain.Repositories;
using BookingSystem.Domain.ValueObjects.Location;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Commands.Handlers
{
    public class AddLocationHandler : IRequestHandler<AddLocation>
    {
        private readonly ILocationRepository _locationRepository;

        public AddLocationHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task Handle(AddLocation request, CancellationToken cancellationToken)
        {

            if(request.FlatNumber is not null)
            {
                Location location = new(Guid.NewGuid(), request.CityName, request.StreetName,
                request.HouseNumber, request.FlatNumber, request.PostalCode);
                await _locationRepository.AddAsync(location);
                await _locationRepository.SaveChangesAsync(cancellationToken);
            }
            else
            {
                Location location = new(Guid.NewGuid(), request.CityName, request.StreetName,
                request.HouseNumber, request.PostalCode);
                await _locationRepository.AddAsync(location);
                await _locationRepository.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
