using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookingSystem.Domain.Exceptions.Employee.EmployeeSurname
{
    public class InvalidEmployeeSurnameLengthException : BookingDomainException
    {
        public InvalidEmployeeSurnameLengthException(string surname) : base($"Employee surname: {surname} must be between 3-35 characters inclusive")
        {
        }
    }
}
