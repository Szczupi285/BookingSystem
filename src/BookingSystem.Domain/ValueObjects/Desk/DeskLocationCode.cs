using BookingSystem.Domain.Exceptions.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Desk
{
    public sealed class DeskLocationCode
    {
        public string Value { get; }

        public DeskLocationCode(string value)
        {
            if(string.IsNullOrEmpty(value))
                throw new DeskLocationCodeCannotBeNullOrEmptyException();

            Value = value;
        }

        public static implicit operator DeskLocationCode(string value) => new(value);

        public static implicit operator string(DeskLocationCode value) => value.Value;
    }
}
