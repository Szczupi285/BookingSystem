using BookingSystem.Domain.Exceptions.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Location
{
    public sealed record CountryName
    {
        public string Value { get; }

        public CountryName(string value)
        {
            if(string.IsNullOrEmpty(value))
                throw new CountryNameCannotBeNullOrEmptyException();
            else if(value.Any(char.IsNumber))
                throw new CountryNameCannotContainNumbersException();

            Value = value;
        }
    }
}
