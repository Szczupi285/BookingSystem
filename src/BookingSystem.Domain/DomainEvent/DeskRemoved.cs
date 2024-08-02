using BookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.DomainEvent
{
    public record DeskRemoved(Location Location, Desk Desk) : IDomainEvent;
}
