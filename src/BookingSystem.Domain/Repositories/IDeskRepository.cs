using BookingSystem.Domain.Entities;
using BookingSystem.Domain.ValueObjects.Desk;
using BookingSystem.Domain.ValueObjects.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Repositories
{
    public interface IDeskRepository
    {
        Task<Desk> GetByIdAsync(DeskId Id);
        Task<IEnumerable<Desk>> GetByLocationAsync();
        Task AddAsync(Desk Desk);
        Task UpdateAsync(Desk Desk);
        Task RemoveAsync(Desk Desk);
        Task SaveChangesAsync(CancellationToken cancellation);
    }
}
