using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.DTO
{
    public record LocationDTO(Guid Id, string CityName, string StreetName, string HouseNumber, string? FlatNumber, string PostalCode);
}
