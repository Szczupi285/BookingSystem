using BookingSystem.Domain.Exceptions.Employee.EmployeeId;
using BookingSystem.Domain.Exceptions.Location;
using BookingSystem.Domain.ValueObjects.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Location
{
    public sealed record LocationId
    {
        public Guid Value { get; }
        public LocationId(Guid value)
        {
            if (value == Guid.Empty)
                throw new EmptyLocationIdException();

            Value = value;
        }

        public static implicit operator Guid(LocationId Id) => Id.Value;

        public static implicit operator LocationId(Guid Id) => new(Id);

    }
}
