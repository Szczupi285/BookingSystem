using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Location.HouseNumber
{
    public class InvalidHouseNumberLengthException : BookingSystemException
    {
        public InvalidHouseNumberLengthException(int maxLen) : base($"House number length cannot be more than {maxLen} characters")
        {
        }
    }
}
