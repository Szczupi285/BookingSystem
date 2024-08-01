﻿using BookingSystem.Domain.Exceptions.Employee.EmployeeName;
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
        public AbstractNamePart(string value, int minLen, int maxLen, BookingDomainException nullCase, BookingDomainException InvLenCase, BookingDomainException NotALetterCase)
        {
            if (value is null)
                throw nullCase;
            else if (minLen < 3 && maxLen > 35)
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