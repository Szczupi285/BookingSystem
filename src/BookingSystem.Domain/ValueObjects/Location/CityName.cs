using BookingSystem.Domain.Abstractions;
using BookingSystem.Domain.Exceptions.Location;
using BookingSystem.Domain.Exceptions.Location.CityName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Location
{
    public sealed record CityName : AbstractPlaceName
    {
        public CityName(string value) : base(value, new CityNameCannotBeNullOrEmptyException(), new CityNameCannotContainNumbersException(value))
        {
        }

        public static implicit operator CityName(string value) => new(value);
    }
}
