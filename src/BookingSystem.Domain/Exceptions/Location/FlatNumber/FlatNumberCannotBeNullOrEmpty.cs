using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Location.FlatNumber
{
    public class FlatNumberCannotBeNullOrEmpty : BookingDomainException
    {
        public FlatNumberCannotBeNullOrEmpty() : base("Flat number cannot be null or empty")
        {
        }
    }
}
