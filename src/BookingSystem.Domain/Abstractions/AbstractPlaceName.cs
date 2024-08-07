using BookingSystem.Domain.Exceptions.Location.CityName;
using BookingSystem.Domain.Exceptions.Location.StreetName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Abstractions
{
    public abstract record AbstractPlaceName
    {
        public string Value { get; }
        private Regex _regex = new(@"^[A-Za-z'.-]$", RegexOptions.None);

        protected AbstractPlaceName(string value,int minLen, int maxLen, BookingSystemException nullCase,BookingSystemException invalidLengthException, BookingSystemException containNumbCase)
        {
           

            if (string.IsNullOrEmpty(value))
                throw nullCase;
            else if (value.Length < 3 || value.Length > 80)
                throw invalidLengthException;
            else if (_regex.IsMatch(value))
                throw containNumbCase;


            Value = value.Trim();
        }

        public static implicit operator string(AbstractPlaceName placeName) => placeName.Value;

    }
}
