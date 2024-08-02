using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Reservation
{
    public class ReservationDateCannotBeInThePastException : BookingSystemException
    {
        public ReservationDateCannotBeInThePastException() : base("Reservation date cannot be in the past")
        {
        }
    }
}
