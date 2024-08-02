using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Employee.EmployeeName
{
    public class InvalidEmployeeNameLengthException : BookingSystemException
    {
        public InvalidEmployeeNameLengthException(string name, int minLen, int maxLen) : base($"Employee name: {name} must be between  {minLen} - {maxLen}  characters inclusive")
        {
        }

    }
}
