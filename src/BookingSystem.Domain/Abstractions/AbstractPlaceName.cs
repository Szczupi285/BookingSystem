using BookingSystem.Domain.Exceptions.Location.CityName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Abstractions
{
    public abstract record AbstractPlaceName
    {
        public string Value { get; }

        protected AbstractPlaceName(string value, BookingDomainException nullCase, BookingDomainException containNumbCase)
        {
            if (string.IsNullOrEmpty(value))
                throw nullCase;
            else if (value.Any(char.IsNumber))
                throw containNumbCase;

            Value = value.Trim();
        }

        public static implicit operator string(AbstractPlaceName placeName) => placeName.Value;

    }
}
