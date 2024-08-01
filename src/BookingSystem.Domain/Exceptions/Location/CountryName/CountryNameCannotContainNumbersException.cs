using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Location.CountryName
{
    public class CountryNameCannotContainNumbersException : BookingDomainException
    {
        public CountryNameCannotContainNumbersException(string name) : base($"Country name: {name} cannot contain any numbers")
        {
        }
    }
}
