using BookingSystem.Domain.Exceptions.Location.PostCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Location
{
    public sealed record PostalCode
    {
        // allowing only two countries postal codes for simplicity
        public string Value { get; }
        private const string _PLPostalCodeRegex = @"^[0-9]{2}-[0-9]{3}";
        public PostalCode(string value)
        {
            if (!Validate(value))
                throw new InvalidPostCodeException(value);
            Value = value;
        }

        private static bool Validate(string postCode)
        {
            Regex Regex = new Regex(_PLPostalCodeRegex);  
            
            return Regex.IsMatch(postCode);
        }

        public static implicit operator string(PostalCode postalCode) => postalCode.Value;

        public static implicit operator PostalCode(string postalCode) => new(postalCode);

    }
}
