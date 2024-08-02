using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Exceptions
{
    public class LocationDoesNotExistsException : BookingSystemException
    {
        public LocationDoesNotExistsException(Guid guid) : base($"Location with Id: {guid} does not exist")
        {
        }
    }
}
