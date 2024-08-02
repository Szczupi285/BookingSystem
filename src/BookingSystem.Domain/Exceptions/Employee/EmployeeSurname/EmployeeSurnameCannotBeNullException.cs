using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Employee.EmployeeSurname
{
    public class EmployeeSurnameCannotBeNullException : BookingSystemException
    {
        public EmployeeSurnameCannotBeNullException() : base("Employee surname cannot be null")
        {
        }
    }
}
