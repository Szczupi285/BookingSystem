using BookingSystem.Domain.Entities;
using BookingSystem.Domain.Repositories;
using BookingSystem.Domain.ValueObjects.Location;
using BookingSystem.Infrastructure.Mappers;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookingSystem.Infrastructure.EF
{
    
    public class LocationRepostiory : ILocationRepository
    {
        private readonly AppDbContext _appDbContext;

        public async Task<Location?> GetByIdAsync(LocationId Id)
        {
            var locationModel = await _appDbContext.Locations
                .SingleOrDefaultAsync(l => l.Id == Id.Value);
            if(locationModel is not null) 
                return LocationMapper.MapToLocation(locationModel);

            return null;

        }
        public async Task AddAsync(Location location)
        {
            var locationModel = LocationMapper.MapToLocationModel(location);
            await _appDbContext.Locations.AddAsync(locationModel);
        }

        public async Task RemoveAsync(Location location)
        {
            var LocationModel = await _appDbContext.Locations
                .SingleOrDefaultAsync(l => l.Id == location.Id.Value);
            if(LocationModel is not null)
                _appDbContext.Locations.Remove(LocationModel);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Location location)
        {
            var existingLocation = await _appDbContext.Locations
             .FirstOrDefaultAsync(l => l.Id == location.Id.Value);

            if (existingLocation is not null)
            {
                existingLocation.City = location.CityName;
                existingLocation.Street = location.StreetName;
                existingLocation.HouseNumber = location.HouseNumber;
                existingLocation.FlatNumber = location.FlatNumber;
                existingLocation.PostalCode = location.PostalCode;

                _appDbContext.Locations.Update(existingLocation);
            }
        }
    }
}
