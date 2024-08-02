using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Administrator.AdministratorSurname
{
    public class AdministratorSurnameCannotBeNullException : BookingSystemException
    {
        public AdministratorSurnameCannotBeNullException() : base("Administrator surname cannot be null")
        {
        }
    }
}
