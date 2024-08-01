using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Reservation
{
    public class ExceededMaximumReservationPeriodException : BookingDomainException
    {
        public ExceededMaximumReservationPeriodException() : base($"Reservation period cannot exceed 7 days")
        {
        }
    }
}
