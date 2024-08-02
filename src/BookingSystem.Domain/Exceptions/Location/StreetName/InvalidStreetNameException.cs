using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Location.StreetName
{
    public class InvalidStreetNameException : BookingSystemException
    {
        public InvalidStreetNameException(string streetName) : base($"Street name: {streetName} can contain only letters")
        {
        }
    }
}
