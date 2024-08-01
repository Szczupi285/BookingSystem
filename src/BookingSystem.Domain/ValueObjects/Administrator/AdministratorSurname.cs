using BookingSystem.Domain.Abstractions;
using BookingSystem.Domain.Exceptions.Administrator.AdministratorSurname;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Administrator
{
    public sealed record AdministratorSurname : AbstractNamePart
    {
        public AdministratorSurname(string value) : base(value, 3, 35, new AdministratorSurnameCannotBeNullException(),
            new InvalidAdministratorSurnameLengthException(value), new InvalidAdministratorSurnameException(value))
        {
        }

        public static implicit operator AdministratorSurname(string name) => new AdministratorSurname(name);
    }
}
