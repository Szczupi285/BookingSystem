using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Location.FlatNumber
{
    public class InvalidFlatNumberLengthException : BookingSystemException
    {
        public InvalidFlatNumberLengthException(string flatNumber) : base($"Flat number: {flatNumber} cannot be bigger than 999")
        {
        }
    }
}
