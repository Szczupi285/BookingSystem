using BookingSystem.Application.Exceptions;
using BookingSystem.Application.Services;
using BookingSystem.Domain.Entities;
using BookingSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Commands.Handlers
{
    public class AddDeskHandler : IRequestHandler<AddDesk>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ILocationReadService _readServiece;

        public AddDeskHandler(ILocationRepository locationRepository, ILocationReadService readServiec)
        {
            _locationRepository = locationRepository;
            _readServiece = readServiec;
        }

        public async Task Handle(AddDesk request, CancellationToken cancellationToken)
        {
            if (!await _readServiece.ExistsByIdAsync(request.locationId))
                throw new LocationDoesNotExistsException(request.locationId);

           Location loc = await _locationRepository.GetByIdAsync(request.locationId);
           loc.AddDesk(new Desk(Guid.NewGuid(), request.LocationCode, request.locationId));
           await _locationRepository.UpdateAsync(loc);
           await _locationRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
