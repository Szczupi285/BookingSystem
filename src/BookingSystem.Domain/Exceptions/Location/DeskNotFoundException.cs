using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Location
{
    public class DeskNotFoundException : BookingSystemException
    {
        public DeskNotFoundException(Guid guid) : base($"Desk with Id: {guid} has not been found")
        {
        }
    }
}
