using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Administrator.AdministratorName
{
    public class InvalidAdministratorNameException : BookingSystemException
    {
        public InvalidAdministratorNameException(string name) : base($"Administrator name: {name} can contain only letters")
        {
        }
    }
}
