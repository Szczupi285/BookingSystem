using BookingSystem.Domain.Exceptions.Location.HouseNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Location
{
    public sealed record HouseNumber
    {
        public string Value { get; }

        public HouseNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new HouseNumberCannotBeNullOrEmptyException();
            if (value.Length > 20)
                throw new InvalidHouseNumberLengthException(20);

            Value = value;  
        }

        public static implicit operator string(HouseNumber houseNumber) => houseNumber.Value;

        public static implicit operator HouseNumber(string houseNumber) => new(houseNumber);
    }
}
