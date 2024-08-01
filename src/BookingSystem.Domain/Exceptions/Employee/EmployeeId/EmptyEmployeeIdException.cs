using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Employee.EmployeeId
{
    public class EmptyEmployeeIdException : BookingDomainException
    {
        public EmptyEmployeeIdException() : base("Employee Id cannot be empty")
        {
        }
    }
}
