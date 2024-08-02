using BookingSystem.Domain.Entities;
using BookingSystem.Domain.ValueObjects.Desk;
using BookingSystem.Domain.ValueObjects.Employee;
using BookingSystem.Domain.ValueObjects.Location;
using BookingSystem.Domain.ValueObjects.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.DomainEvent
{
    public record DeskReserved(LocationId LocationId ,DeskId DeskId, EmployeeId EmployeeId, ReservationPeriod ReservationPeriod) : IDomainEvent;
}
