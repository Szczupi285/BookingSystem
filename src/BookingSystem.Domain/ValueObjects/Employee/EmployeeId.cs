using BookingSystem.Domain.Exceptions;
using BookingSystem.Domain.Exceptions.Employee.EmployeeId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Employee
{
    public sealed record EmployeeId
    {
        public Guid Value { get; }
        public EmployeeId(Guid value)
        {
            if(value == Guid.Empty)
                throw new EmptyEmployeeIdException();

            Value = value;
        }

        public static implicit operator Guid(EmployeeId Id) => Id.Value;

        public static implicit operator EmployeeId(Guid Id) => new(Id);
    }
}
