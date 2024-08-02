using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Location.HouseNumber
{
    public class HouseNumberCannotBeNullOrEmptyException : BookingSystemException
    {
        public HouseNumberCannotBeNullOrEmptyException() : base($"House number cannot be null or empty")
        {
        }
    }
}
