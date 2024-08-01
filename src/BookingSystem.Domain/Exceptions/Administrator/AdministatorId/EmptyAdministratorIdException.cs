using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Administrator.AdministatorId
{
    public class EmptyAdministratorIdException : BookingDomainException
    {
        public EmptyAdministratorIdException() : base("Administator Id cannot be empty")
        {
        }
    }
}
