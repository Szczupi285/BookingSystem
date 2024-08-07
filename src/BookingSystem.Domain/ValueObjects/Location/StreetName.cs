using BookingSystem.Domain.Abstractions;
using BookingSystem.Domain.Exceptions.Location.CityName;
using BookingSystem.Domain.Exceptions.Location.StreetName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Location
{
    public sealed record StreetName : AbstractPlaceName
    {
        public StreetName(string value) : base(value, 3, 80, new CityNameCannotBeNullOrEmptyException(),
            new InvalidCityNameLengthException(value, 3, 80), new CityNameCannotContainNumbersException(value))
        { }

        public static implicit operator StreetName(string postalCode) => new(postalCode);
    }
}
