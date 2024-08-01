using BookingSystem.Domain.ValueObjects.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities
{
    public class Employee
    {
        public EmployeeId Id { get; }
        public EmployeeName Name { get; }
        public EmployeeSurname Surname { get; }
        public Employee(EmployeeId id, EmployeeName name, EmployeeSurname surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }
    }
}
