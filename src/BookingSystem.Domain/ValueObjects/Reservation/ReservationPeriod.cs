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
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public ReservationPeriod(DateTime startDate, DateTime endDate,  IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
            if (startDate > endDate)
                throw new ReservationCannotEndBeforeItStartsException(startDate, endDate);
            else if (startDate < _dateTimeProvider.Now())
                throw new ReservationDateCannotBeInThePastException();
            else if ((endDate - startDate).TotalSeconds > 604800)
                throw new ExceededMaximumReservationPeriodException();


            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
