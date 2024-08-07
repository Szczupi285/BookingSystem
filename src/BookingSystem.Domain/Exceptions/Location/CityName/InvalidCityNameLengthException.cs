using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Location.CityName
{
    public class InvalidCityNameLengthException : BookingSystemException
    {
        public InvalidCityNameLengthException(string CityName, int minLen, int maxLen) : base($"CityName: {CityName} must be between  {minLen} - {maxLen}  characters inclusive\"")
        {
        }
    }
}
