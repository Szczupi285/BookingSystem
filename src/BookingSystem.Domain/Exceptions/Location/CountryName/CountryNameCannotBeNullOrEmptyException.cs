using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Location.CountryName
{
    public class CountryNameCannotBeNullOrEmptyException : BookingDomainException
    {
        public CountryNameCannotBeNullOrEmptyException() : base("Country cannot be null or empty")
        {
        }
    }
}
