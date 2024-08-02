using BookingSystem.Domain.Exceptions.Reservation;
using BookingSystem.Domain.ValueObjects.Desk;
using BookingSystem.Domain.ValueObjects.Employee;
using BookingSystem.Domain.ValueObjects.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities
{
    public class Reservation
    {
        public ReservationId Id { get; }
        public ReservationPeriod Period { get; private set; }
        public DeskId DeskId { get; private set; }
        public EmployeeId EmployeeId { get; private set; }

        public Reservation(ReservationId id, ReservationPeriod period, DeskId deskId, EmployeeId employeeId)
        {
            Id = id;
            Period = period;
            DeskId = deskId;
            EmployeeId = employeeId;
        }

        public bool CanChangeReservation()
        {
            if (Period.StartDate <= DateTime.UtcNow.AddHours(24))
                return false;
            return true;
        }
        internal void ChangeReservation(DeskId newDeskId)
        {
            if (Period.StartDate <= DateTime.UtcNow.AddHours(24))
                throw new TooLateCancellationException();
            else
                DeskId = newDeskId;
        }

    }
}
