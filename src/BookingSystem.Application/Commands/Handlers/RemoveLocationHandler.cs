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
    public class RemoveLocationHandler : IRequestHandler<RemoveLocation>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ILocationReadService _readServiece;

        public RemoveLocationHandler(ILocationRepository locationRepository, ILocationReadService readServiec)
        {
            _locationRepository = locationRepository;
            _readServiece = readServiec;
        }
        public async Task Handle(RemoveLocation request, CancellationToken cancellationToken)
        {
            if (!await _readServiece.ExistsByIdAsync(request.LocationId))
                throw new LocationDoesNotExistsException(request.LocationId);


            await _locationRepository.RemoveAsync(request.LocationId);
            await _locationRepository.SaveChangesAsync(cancellationToken);
           



        }
    }
}
