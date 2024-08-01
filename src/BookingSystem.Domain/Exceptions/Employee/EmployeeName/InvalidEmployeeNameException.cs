using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Employee.EmployeeName
{
    public class InvalidEmployeeNameException : BookingDomainException
    {
        public InvalidEmployeeNameException(string name) : base($"Employee name: {name} can contain only letters")
        {
        }
    }
}
