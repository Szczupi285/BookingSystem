using BookingSystem.Domain.ValueObjects.Administrator;
using BookingSystem.Domain.ValueObjects.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities
{
    public class Administrator
    {
        public AdministratorId Id { get; }
        public AdministratorName Name { get; }
        public AdministratorSurname Surname { get; }
        public Administrator(AdministratorId id, AdministratorName name, AdministratorSurname surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }
    }
}
