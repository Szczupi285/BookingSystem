using BookingSystem.Domain.Abstractions;
using BookingSystem.Domain.Exceptions.Administrator.AdministratorName;
using BookingSystem.Domain.ValueObjects.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects.Administrator
{
    public record AdministratorName : AbstractNamePart
    {
        public AdministratorName(string value) : base(value, 3, 35, new AdministratorNameCannotBeNullException(), 
            new InvalidAdministratorNameLengthException(value), new InvalidAdministratorNameException(value))
        {
        }

        public static implicit operator AdministratorName(string name) => new AdministratorName(name);

    }
}
