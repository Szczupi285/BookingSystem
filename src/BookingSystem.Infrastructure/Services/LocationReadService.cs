using BookingSystem.Application.Services;
using BookingSystem.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Services
{
    public class LocationReadService : ILocationReadService
    {
        private readonly AppDbContext _appDbContext;

        public LocationReadService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> ExistsByIdAsync(Guid id)
        {
            var result = await _appDbContext.Locations
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if(result is null)
                return false;
            return true;

        }
    }
}
