using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Location.StreetName
{
    public class StreetNameCannotBeNullOrEmptyException : BookingSystemException
    {
        public StreetNameCannotBeNullOrEmptyException() : base($"Street name cannot be null or empty")
        {
        }
    }
}
