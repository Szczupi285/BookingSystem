using BookingSystem.Application.Exceptions;
using BookingSystem.Application.Services;
using BookingSystem.Domain.DateTimeProvider;
using BookingSystem.Domain.Entities;
using BookingSystem.Domain.Repositories;
using BookingSystem.Domain.ValueObjects.Reservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Commands.Handlers
{
    public class ReserveDeskHandler : IRequestHandler<ReserveDesk>
    {

        private readonly ILocationRepository _locationRepository;
        private readonly ILocationReadService _readServiece;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ReserveDeskHandler(ILocationRepository locationRepository, ILocationReadService readServiec, IDateTimeProvider dateTimeProvider)
        {
            _locationRepository = locationRepository;
            _readServiece = readServiec;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task Handle(ReserveDesk request, CancellationToken cancellationToken)
        {
            if (!await _readServiece.ExistsByIdAsync(request.LocationId))
                throw new LocationDoesNotExistsException(request.LocationId);

            Location loc = await _locationRepository.GetByIdAsync(request.LocationId);
            Desk desk = loc.GetDeskById(request.DeskId);

            var startDate = new DateTime(request.startDate.Year, request.startDate.Month, request.startDate.Day, 0,0,0);

            ReservationPeriod resPe = new(startDate, startDate.AddDays(request.numOfDays).AddSeconds(-1), _dateTimeProvider);
            Reservation res = new Reservation(Guid.NewGuid(), resPe, request.DeskId, request.EmployeeId);

            desk.AddReservation(res);

            await _locationRepository.UpdateAsync(loc);
            await _locationRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
