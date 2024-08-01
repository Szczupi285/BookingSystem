using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Administrator.AdministratorSurname
{
    internal class InvalidAdministratorSurnameLengthException : BookingDomainException
    {
        public InvalidAdministratorSurnameLengthException(string surname, int minLen, int maxLen) : base($"Administrator surname: {surname} must be between {minLen} - {maxLen} characters inclusive")
        {
        }
    }
}
