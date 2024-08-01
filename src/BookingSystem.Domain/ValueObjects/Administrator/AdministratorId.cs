using BookingSystem.Domain.Exceptions.Administrator;
using BookingSystem.Domain.Exceptions.Employee.EmployeeId;
using BookingSystem.Domain.ValueObjects.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Administrator
{
    public record AdministratorId
    {
        public Guid Value { get; }
        public AdministratorId(Guid value)
        {
            if (value == Guid.Empty)
                throw new EmptyAdministratorIdException();

            Value = value;
        }

        public static implicit operator Guid(AdministratorId Id) => Id.Value;

        public static implicit operator AdministratorId(Guid Id) => new(Id);
    }
}
