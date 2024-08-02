using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Location
{
    public class CannotRemoveReservedDeskException : BookingSystemException
    {
        public CannotRemoveReservedDeskException() : base("Desk cannot be removed if it has been booked")
        {
        }
    }
}
