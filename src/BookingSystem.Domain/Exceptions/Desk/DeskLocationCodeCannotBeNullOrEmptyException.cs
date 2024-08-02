using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Desk
{
    public class DeskLocationCodeCannotBeNullOrEmptyException : BookingDomainException
    {
        public DeskLocationCodeCannotBeNullOrEmptyException() : base("Desk location code cannot be null or empty")
        {
        }
    }
}
