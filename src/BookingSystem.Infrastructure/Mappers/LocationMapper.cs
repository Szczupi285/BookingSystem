using BookingSystem.Domain.Entities;
using BookingSystem.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Mappers
{
    internal static class LocationMapper
    {
        internal static Location MapToLocation(LocationModel locationModel)
        {
            return new Location
                (
                locationModel.Id,
                locationModel.City,
                locationModel.Street,
                locationModel.HouseNumber,
                locationModel.FlatNumber,
                locationModel.PostalCode
                );
        }
        internal static LocationModel MapToLocationModel(Location location)
        {
            return new LocationModel
            {
                Id = location.Id,
                City = location.CityName,
                Street = location.StreetName,
                HouseNumber = location.HouseNumber,
                FlatNumber = location.FlatNumber,
                PostalCode = location.PostalCode
            };
        }
    }
}
