using BookingSystem.Domain.Entities;
using BookingSystem.Domain.ValueObjects.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.DomainEvent
{
    public record DeskMadeUnavailable(Desk Desk) : IDomainEvent;
}
