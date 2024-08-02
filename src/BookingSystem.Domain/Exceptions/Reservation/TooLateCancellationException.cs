using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Reservation
{
    public class TooLateCancellationException : BookingDomainException
    {
        public TooLateCancellationException() : base("Reservation cannot be removed within 24 hours before the reservation start")
        {
        }
    }
}
