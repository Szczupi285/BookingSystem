using BookingSystem.Domain.Abstractions;
using BookingSystem.Domain.Exceptions.Employee.EmployeeSurname;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Employee
{
    public sealed record EmployeeSurname : AbstractNamePart
    {
        public EmployeeSurname(string value) : base(value, 3, 35, new EmployeeSurnameCannotBeNullException(),
            new InvalidEmployeeSurnameLengthException(value), new InvalidEmployeeSurnameException(value))
        {
        }

        public static implicit operator EmployeeSurname(string surname) => new EmployeeSurname(surname);

    }
}
