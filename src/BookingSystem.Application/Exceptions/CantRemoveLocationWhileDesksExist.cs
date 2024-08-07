using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Exceptions
{
    public class CantRemoveLocationWhileDesksExist : BookingSystemException
    {
        public CantRemoveLocationWhileDesksExist() : base("Location can be removed only if it doesn't have any desks")
        {
        }
    }
}
