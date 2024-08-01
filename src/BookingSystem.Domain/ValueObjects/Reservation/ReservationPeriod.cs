using BookingSystem.Domain.DateTimeProvider;
using BookingSystem.Domain.Exceptions.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Reservation
{
    public sealed record ReservationPeriod
    {
        private IDateTimeProvider _dateTimeProvider;
        public DateOnly StartDate { get; }
        public DateTime EndDate { get; }

        public ReservationPeriod(DateOnly startDate, DateOnly endDate,  IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
            if (startDate > endDate)
                throw new ReservationCannotEndBeforeItStartsException(startDate, endDate);
            else if (startDate < DateOnly.FromDateTime(_dateTimeProvider.UtcNow()))
                throw new ReservationDateCannotBeInThePastException();
            // Equal startDate and endDate means a 1 day reservation but the day difference will be equal to 0.
            // Because of that day difference must be 6 at most so if we start at monday the last day that we can reserve is sunday
            else if ((endDate.DayNumber - startDate.DayNumber) >= 7)
                throw new ExceededMaximumReservationPeriodException();

        }
    }
}
