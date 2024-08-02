using BookingSystem.Domain.Exceptions.Employee.EmployeeName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Abstractions
{
    public abstract record AbstractNamePart
    {
        public string Value { get; }
        protected AbstractNamePart(string value, int minLen, int maxLen, BookingSystemException nullCase, BookingSystemException InvLenCase, BookingSystemException NotALetterCase)
        {
            if (value is null)
                throw nullCase;
            else if (value.Length < minLen || value.Length > maxLen)
                throw InvLenCase;
            else if (!value.All(char.IsLetter))
                throw NotALetterCase;

            Value = Normalize(value);
        }

        private static string Normalize(string value)
        {
            return char.ToUpper(value[0]) + value[1..].ToLower().Trim();
        }

        public static implicit operator string(AbstractNamePart part) => part.Value;
    }
}
