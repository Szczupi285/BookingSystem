using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Desk
{
    public class DeskNotAvailableForReservationException : BookingSystemException
    {
        public DeskNotAvailableForReservationException() : base($"Desk is either unavailable or someone reserved it already")
        {
        }
    }
}
