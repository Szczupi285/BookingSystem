using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Desk
{
    public class ReservationNotFoundException : BookingDomainException
    {
        public ReservationNotFoundException(Guid guid) : base($"Reservation with Id: {guid} has not been found")
    }
}
