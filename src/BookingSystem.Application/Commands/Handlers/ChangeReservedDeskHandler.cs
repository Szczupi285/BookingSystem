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
    public class ChangeReservedDeskHandler : IRequestHandler<ChangeReservedDesk>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ILocationReadService _readServiece;

        public ChangeReservedDeskHandler(ILocationRepository locationRepository, ILocationReadService readServiec)
        {
            _locationRepository = locationRepository;
            _readServiece = readServiec;
        }

        public async Task Handle(ChangeReservedDesk request, CancellationToken cancellationToken)
        {
            if (!await _readServiece.ExistsByIdAsync(request.LocationId))
                throw new LocationDoesNotExistsException(request.LocationId);

            Location loc = await _locationRepository.GetByIdAsync(request.LocationId);
            loc.ChangeDesk(request.LocationId,request.oldDeskId, request.NewDeskId, request.ReservationId, request.EmployeeId);

            _locationRepository.UpdateAsync(loc);
            await _locationRepository.SaveChangesAsync(cancellationToken);
           
        }
    }
}
