using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Location.PostCode
{
    public class InvalidPostCodeException : BookingDomainException
    {
        public InvalidPostCodeException(string postcode) : base($"Provided post code: {postcode} is invalid")
        {
        }
    }
}
