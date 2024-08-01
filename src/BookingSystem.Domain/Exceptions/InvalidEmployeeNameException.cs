using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions
{
    public class InvalidEmployeeNameException : BookingDomainException
    {
        public InvalidEmployeeNameException(string name) : base($"Employee name: {name} cannot contain special characters")
        {
        }
    }
}
