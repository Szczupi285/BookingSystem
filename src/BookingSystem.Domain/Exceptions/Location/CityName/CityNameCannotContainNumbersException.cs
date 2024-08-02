using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Location.CityName
{
    public class CityNameCannotContainNumbersException : BookingSystemException
    {
        public CityNameCannotContainNumbersException(string name) : base($"City name: {name} cannot contain any numbers")
        {
        }
    }
}
