using BookingSystem.Domain.Exceptions.Location.StreetName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Location
{
    public sealed record StreetName
    {
        public string Value { get; }

        public StreetName(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new StreetNameCannotBeNullOrEmptyException();
            else if (value.Length < 3 || value.Length > 80)
                throw new InvalidStreetNameLengthException(value, 3, 80);
            else if (!value.All(char.IsLetter))
                throw new InvalidStreetNameException(value);

            Value = value;
        }
    }
}
