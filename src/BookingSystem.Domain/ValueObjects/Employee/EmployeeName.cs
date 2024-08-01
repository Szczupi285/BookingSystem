using BookingSystem.Domain.Abstractions;
using BookingSystem.Domain.Exceptions;
using BookingSystem.Domain.Exceptions.Employee.EmployeeName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Employee
{
    public sealed record EmployeeName : AbstractNamePart
    {
        public EmployeeName(string value) : base(value, 3, 35, new EmployeeNameCannotBeNullException(),
            new InvalidEmployeeNameLengthException(value), new InvalidEmployeeNameException(value))
        {
        }

        public static implicit operator EmployeeName(string name) => new EmployeeName(name);
    }
}
