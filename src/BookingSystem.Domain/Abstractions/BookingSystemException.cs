using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Abstractions
{
    public abstract class BookingSystemException : Exception
    {
        protected BookingSystemException(string message) : base(message) { }
    }
}

