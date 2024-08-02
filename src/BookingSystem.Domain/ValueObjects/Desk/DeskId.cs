using BookingSystem.Domain.Exceptions.Desk;
using BookingSystem.Domain.ValueObjects.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Desk
{
    public sealed record DeskId
    {
        public Guid Value { get; }
        public DeskId(Guid value)
        {
            if (value == Guid.Empty)
                throw new EmptyDeskIdException();

            Value = value;
        }

        public static implicit operator Guid(DeskId Id) => Id.Value;

        public static implicit operator DeskId(Guid Id) => new(Id);
    }
}
