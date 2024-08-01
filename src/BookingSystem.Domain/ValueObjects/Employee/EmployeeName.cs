using BookingSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Employee
{
    public record EmployeeName
    {
        public string Value { get; }
        public EmployeeName(string value)
        {
            if (value is null)
                throw new EmployeeNameCannotBeNullException();
            else if (value.Length < 3 && value.Length > 35)
                throw new InvalidEmployeeNameLengthException(value);
            else if (!value.All(char.IsLetter))
                throw new InvalidEmployeeNameException(value);

            Value = char.ToUpper(value[0]) + value[1..].ToLower();
        }
    }
}
