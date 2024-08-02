using BookingSystem.Domain.Abstractions;
using BookingSystem.Domain.Consts;
using BookingSystem.Domain.DateTimeProvider;
using BookingSystem.Domain.DomainEvent;
using BookingSystem.Domain.Exceptions.Desk;
using BookingSystem.Domain.Exceptions.Reservation;
using BookingSystem.Domain.ValueObjects.Desk;
using BookingSystem.Domain.ValueObjects.Location;
using BookingSystem.Domain.ValueObjects.Reservation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        internal void MakeUnavailiable()
        {
            Availability = AvailabilityEnum.Unavailable;
        }

        internal void MakeAvailiable()
        {
            Availability = AvailabilityEnum.Available;
        }
        private bool CanReserve(ReservationPeriod reservationPeriod)
        {
            if(Availability == AvailabilityEnum.Unavailable) 
                return false;
            foreach(Reservation reservation in _reservations)
            {
                if (DoesOverlap(reservationPeriod, reservation.Period))
                    return false;
            }
            return true;    
        }
        public bool HaveFutureReservations()
        {
            foreach(Reservation reservation in _reservations)
                if(reservation.Period.StartDate > DateTime.UtcNow)
                    return true;

            return false;
        }
        private bool DoesOverlap(ReservationPeriod resPeriod1, ReservationPeriod resPeriod2)
            => resPeriod1.StartDate <= resPeriod2.EndDate && resPeriod2.StartDate <= resPeriod1.EndDate;

        public void AddReservation(Reservation reservation)
        {
            if (CanReserve(reservation.Period))
            {
                _reservations.Add(reservation);
            }
            throw new DeskNotAvailableForReservationException();
        }
      
        internal Reservation GetReservationById(ReservationId Id)
        {
            var res = _reservations.FirstOrDefault(reservation => reservation.Id == Id) ?? throw new ReservationNotFoundException(Id);
            return res;
        }
    }
}
