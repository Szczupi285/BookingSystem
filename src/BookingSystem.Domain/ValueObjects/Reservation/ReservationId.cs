using BookingSystem.Domain.Exceptions.Location.LocationId;
using BookingSystem.Domain.Exceptions.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Reservation
{
    public sealed record ReservationId
    {
        public Guid Value { get; }
        public ReservationId(Guid value)
        {
            if (value == Guid.Empty)
                throw new EmptyReservationIdException();

            Value = value;
        }

        public static implicit operator Guid(ReservationId Id) => Id.Value;

        public static implicit operator ReservationId(Guid Id) => new(Id);

    }
}
