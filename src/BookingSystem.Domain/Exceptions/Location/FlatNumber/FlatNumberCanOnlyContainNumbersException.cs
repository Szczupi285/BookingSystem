using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Location.FlatNumber
{
    public class FlatNumberCanOnlyContainNumbersException : BookingDomainException
    {
        public FlatNumberCanOnlyContainNumbersException(string flatNumber) : base($"Flat number: {flatNumber} can only contain numbers.")
        {
        }
    }
}
