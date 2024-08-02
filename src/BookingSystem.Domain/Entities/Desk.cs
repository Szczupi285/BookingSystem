using BookingSystem.Domain.Consts;
using BookingSystem.Domain.ValueObjects.Desk;
using BookingSystem.Domain.ValueObjects.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities
{
    public class Desk
    {
        public DeskId Id { get; }
        public DeskLocationCode LocationCode { get; private set; }
        public LocationId LocationId { get; private set; }
        public AvailabilityEnum Availability { get; private set; }

        private ICollection<Reservation> _reservations;

        public Desk(DeskId id, DeskLocationCode locationCode, LocationId locationId)
        {
            Id = id;
            LocationCode = locationCode;
            LocationId = locationId;
            Availability = AvailabilityEnum.Available;
            _reservations = new List<Reservation>();
        }

    }
}
