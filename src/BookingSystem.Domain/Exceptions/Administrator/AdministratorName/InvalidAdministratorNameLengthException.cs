using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookingSystem.Domain.Exceptions.Administrator.AdministratorName
{
    public class InvalidAdministratorNameLengthException : BookingSystemException
    {
        public InvalidAdministratorNameLengthException(string name, int minLen, int maxLen) : base($"Administrator name: {name} must be between {minLen} - {maxLen} characters inclusive")
        {
        }
    }
}
