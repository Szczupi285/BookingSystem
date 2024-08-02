using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Location.LocationId
{
    public class EmptyLocationIdException : BookingSystemException
    {
        public EmptyLocationIdException() : base("Location Id cannot be empty")
        {
        }
    }
}
