using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Administrator.AdministratorName
{
    public class AdministratorNameCannotBeNullException : BookingSystemException
    {
        public AdministratorNameCannotBeNullException() : base("Administator name cannot be null")
        {
        }
    }
}
