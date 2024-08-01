using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions
{
    public class InvalidEmployeeNameLengthException : BookingDomainException
    {
        public InvalidEmployeeNameLengthException(string name) : base($"Employee name: {name} must be between 3-35 characters inclusive")
        {
        }
    }
}
