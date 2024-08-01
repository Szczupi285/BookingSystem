using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.DateTimeProvider
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow();
        DateTime Now();
    }
}
