using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Location.CityName
{
    public class CityNameCannotBeNullOrEmptyException : BookingDomainException
    {
        public CityNameCannotBeNullOrEmptyException() : base("City name cannot be null or empty")
        {
        }
    }
}
