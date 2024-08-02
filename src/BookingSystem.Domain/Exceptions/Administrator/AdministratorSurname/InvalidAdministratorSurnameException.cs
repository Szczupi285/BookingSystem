using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Administrator.AdministratorSurname
{
    public class InvalidAdministratorSurnameException : BookingSystemException
    {
        public InvalidAdministratorSurnameException(string surname) : base($"Administrator surname: {surname} can contain only letters")
        {
        }
    }
}
