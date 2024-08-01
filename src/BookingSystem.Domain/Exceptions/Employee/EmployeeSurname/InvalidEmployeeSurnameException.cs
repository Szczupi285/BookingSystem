using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookingSystem.Domain.Exceptions.Employee.EmployeeSurname
{
    public class InvalidEmployeeSurnameException : BookingDomainException
    {
        public InvalidEmployeeSurnameException(string surname) : base($"Employee surname: {surname} can contain only letters")
        {
        }

    }
}
