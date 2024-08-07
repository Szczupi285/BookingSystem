﻿using BookingSystem.Application.Commands;
using BookingSystem.Domain.Consts;
using BookingSystem.Domain.DomainEvent;
using BookingSystem.Domain.Entities;
using BookingSystem.Domain.Repositories;
using BookingSystem.Domain.ValueObjects.Location;
using BookingSystem.Infrastructure.EF.Models;
using BookingSystem.Infrastructure.Mappers;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace BookingSystem.Infrastructure.EF
{
    
    public class LocationRepostiory : ILocationRepository
    {
        private readonly AppDbContext _appDbContext;

        public LocationRepostiory(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Location?> GetByIdAsync(LocationId Id)
        {
            var locationModel = await _appDbContext.Locations
                .AsNoTracking()
                .Include(l => l.Desks)
                .ThenInclude(d => d.Reservations)
                .ThenInclude(u => u.User)
                .SingleOrDefaultAsync(l => l.Id == Id.Value);
            
            
            if (locationModel is not null)
            {
                return LocationMapper.MapToLocation(locationModel);
            }

            return null;

        }
        public async Task AddAsync(Location location)
        {
            var locationModel = LocationMapper.MapToLocationModel(location);
            await _appDbContext.Locations.AddAsync(locationModel);
        }

        public async Task RemoveAsync(LocationId locationId)
        {
            var LocationModel = await _appDbContext.Locations
                .SingleOrDefaultAsync(l => l.Id == locationId.Value);
            if(LocationModel is not null)
                _appDbContext.Locations.Remove(LocationModel);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Location location)
        {
            var dbModel = await _appDbContext.Locations
                .AsNoTracking()
                .Include(l => l.Desks)
                .ThenInclude(d => d.Reservations)
                .SingleOrDefaultAsync(l => l.Id == location.Id.Value);

           
            var locationModel = LocationMapper.MapToLocationModel(location);
            _appDbContext.Attach(locationModel).State = EntityState.Modified;
            // Checking if Desk from updated location model exists in DbModel. 
            // If not we attach desk and mark it state as Added.
            foreach(var dsk in locationModel.Desks) 
            {
                var dbDesk = dbModel.Desks.FirstOrDefault(d => d.Id == dsk.Id);
                // Add Desk if in exists in locationModel and doesn't in dbModel
                if (!dbModel.Desks.Any(d => d.Id == dsk.Id))
                    _appDbContext.Attach(dsk).State = EntityState.Added;
                // Try to update properties only if DbDest is not null
                if(dbDesk != null) 
                {
                    // Update Availability if it has changed
                    if (dbDesk.Availability != dsk.Availability)
                    {
                        _appDbContext.Entry(dsk).Property(d => d.Availability).IsModified = true;
                    }
                    else if (dbDesk.DeskLocationCode != dsk.DeskLocationCode)
                    {
                        _appDbContext.Entry(dsk).Property(d => d.DeskLocationCode).IsModified = true;
                    }

                    foreach (var reservation in dsk.Reservations)
                    {
                        // add reservation if res doesn't exist in dbDesk
                        if (!dbDesk.Reservations.Any(r => r.Id == reservation.Id))
                        {
                            _appDbContext.Attach(reservation).State = EntityState.Added;
                        }
                    }

                    // delete reservations if they don't exist in locationModel.Desks
                    var reservationsToDel = dbDesk.Reservations
                    .Where(r => !dsk.Reservations.Any(ld => ld.Id == r.Id)).ToList();
                    foreach (var reservation in reservationsToDel)
                    {
                        _appDbContext.Entry(reservation).State = EntityState.Deleted;
                        dbDesk.Reservations.Remove(reservation);
                    }
                }
            }


            // Retriving desks that exist in DbModel but does not exist in updated location model.
            // which means they've been deleted in memory.
            var desksToDel = dbModel.Desks.Where(d => !locationModel.Desks.Any(ld => ld.Id == d.Id)).ToList();
            foreach (var dsk in desksToDel)
            {
                // Setting state of desks that have been deleted in memory to Deleted and removing them.
                _appDbContext.Entry(dsk).State = EntityState.Deleted;
                locationModel.Desks.Remove(dsk);
            }

            _appDbContext.Locations.Update(locationModel);
        }

    }
}
