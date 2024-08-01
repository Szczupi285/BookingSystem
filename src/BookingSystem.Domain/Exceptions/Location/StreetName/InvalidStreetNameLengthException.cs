using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Location.StreetName
{
    public class InvalidStreetNameLengthException : BookingDomainException
    {
        public InvalidStreetNameLengthException(string streetName, int minLen, int maxLen) : base($"StreetName: {streetName} must be between  {minLen} - {maxLen}  characters inclusive\"")
        {
        }
    }
}
