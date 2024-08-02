using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Services
{
    public interface ILocationReadService
    {
        Task<bool> ExistsByIdAsync(Guid id);
    }
}
