using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Location
{
    public class DeskCannotBeNullException : BookingDomainException
    {
        public DeskCannotBeNullException() : base("Desk cannot be null")
        {
        }
    }
}
