using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookingSystem.Domain.Exceptions.Administrator.AdministratorName
{
    public class InvalidAdministratorNameLengthException : BookingDomainException
    {
        public InvalidAdministratorNameLengthException(string name) : base($"Administrator name: {name} must be between 3-35 characters inclusive")
        {
        }
    }
}
