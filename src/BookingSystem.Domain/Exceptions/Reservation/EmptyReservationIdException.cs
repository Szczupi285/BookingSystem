using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Reservation
{
    public class EmptyReservationIdException : BookingSystemException
    {
        public EmptyReservationIdException() : base("Reservation Id cannot be empty")
        {
        }
    }
}
