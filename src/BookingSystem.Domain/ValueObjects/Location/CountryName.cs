using BookingSystem.Domain.Abstractions;
using BookingSystem.Domain.Exceptions.Location;
using BookingSystem.Domain.Exceptions.Location.CountryName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Location
{
    public sealed record CountryName : AbstractPlaceName
    {
        public CountryName(string value) : base(value, new CountryNameCannotBeNullOrEmptyException(), new CountryNameCannotContainNumbersException(value))
        {
        }

        public static implicit operator CountryName(string value) => new(value);
    }
}
