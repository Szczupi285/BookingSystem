using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Abstractions
{
    public abstract class BookingDomainException : Exception
    {
        protected BookingDomainException(string message) : base(message) { }
    }
}

