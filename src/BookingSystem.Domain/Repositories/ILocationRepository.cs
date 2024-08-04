using BookingSystem.Domain.Entities;
using BookingSystem.Domain.ValueObjects.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Repositories
{
    public interface ILocationRepository
    {
        Task<Location?> GetByIdAsync(LocationId Id);
        Task AddAsync(Location location);
        Task UpdateAsync(Location location);
        Task RemoveAsync(Location location);
        Task SaveChangesAsync(CancellationToken cancellation);
    }
}
