using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Employee.EmployeeName
{
    public class EmployeeNameCannotBeNullException : BookingDomainException
    {
        public EmployeeNameCannotBeNullException() : base("Employee name cannot be null")
        {
        }
    }
}
