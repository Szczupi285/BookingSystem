using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Commands
{
    public record AddLocation(string CityName, string StreetName, string HouseNumber, string? FlatNumber, string PostalCode) : IRequest;
}
