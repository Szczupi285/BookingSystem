using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Location
{
    public class ReservationNotOwnedByUserException : BookingSystemException
    {
        public ReservationNotOwnedByUserException(Guid guid) : base($"User with Guid: {guid} is not the one that reserved this desk")
        {
        }
    }
}
