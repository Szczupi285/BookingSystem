using BookingSystem.Domain.Abstractions;
using BookingSystem.Domain.Exceptions.Location.FlatNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Location
{
    public sealed record FlatNumber
    {
        public string Value { get; }

        public FlatNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new FlatNumberCannotBeNullOrEmpty();
            if (!value.All(char.IsNumber))
                throw new FlatNumberCanOnlyContainNumbersException(value);
            if(value.Length > 3)
                throw new InvalidFlatNumberLengthException(value);

            Value = value;
        }
    }
}
