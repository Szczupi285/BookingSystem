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
        public InvalidEmployeeSurnameLengthException(string surname, int minLen, int maxLen) : base($"Employee surname: {surname} must be between {minLen} - {maxLen} characters inclusive")
        {
        }
    }
}
