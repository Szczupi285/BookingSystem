using BookingSystem.Domain.Abstractions;
using BookingSystem.Domain.DomainEvent;
using BookingSystem.Domain.Exceptions.Desk;
using BookingSystem.Domain.Exceptions.Location;
using BookingSystem.Domain.ValueObjects.Desk;
using BookingSystem.Domain.ValueObjects.Location;
using BookingSystem.Domain.ValueObjects.Reservation;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Domain.Entities
{
    public class Location : AggregateRoot<LocationId>
    {
        public CityName CityName { get; private set; }
        public StreetName StreetName { get; private set; }
        public HouseNumber HouseNumber { get; private set; }
        public FlatNumber? FlatNumber { get; private set; }
        public PostalCode PostalCode { get; private set; }
        public HashSet<Desk> Desks { get; private set;}

        public Location(LocationId id, CityName cityName, StreetName streetName, 
            HouseNumber houseNumber, FlatNumber flatNumber, PostalCode postalCode)
        {
            Id = id;
            CityName = cityName;
            StreetName = streetName;
            HouseNumber = houseNumber;
            FlatNumber = flatNumber;
            PostalCode = postalCode;
            Desks = new HashSet<Desk>();
        }
        public Location(LocationId id, CityName cityName, StreetName streetName,
          HouseNumber houseNumber, PostalCode postalCode)
        {
            Id = id;
            CityName = cityName;
            StreetName = streetName;
            HouseNumber = houseNumber;
            FlatNumber = null;
            PostalCode = postalCode;
            Desks = new HashSet<Desk>();
        }

        public Desk GetDeskById(DeskId deskId)
        {
            var desk = Desks.FirstOrDefault(d => d.Id == deskId);
            return desk is null ? throw new DeskNotFoundException(deskId) : desk;
        }
        public void AddDesk(Desk desk) 
        { 
            if(desk is null)
                throw new DeskCannotBeNullException();
            Desks.Add(desk);

            AddEvent(new DeskAdded(this, desk));
        }
        public void RemoveDesk(DeskId deskId)
        {
            var desk = GetDeskById(deskId);

            if(desk.HaveFutureReservations())
                throw new CannotRemoveReservedDeskException();
            
            Desks.Remove(desk);

            AddEvent(new DeskRemoved(this, desk));
        }
        public void MakeDeskUnavailiable(DeskId deskId)
        {
            var desk = GetDeskById(deskId);
            desk.MakeUnavailiable();

            AddEvent(new DeskMadeUnavailable(desk));
        }
        public void MakeDeskAvailiable(DeskId deskId)
        {
            var desk = GetDeskById(deskId);
            desk.MakeAvailiable();

            AddEvent(new DeskMadeAvailable(desk));
        }
        public void ChangeDesk(DeskId deskId, ReservationId reservationId)
        {
            var desk = GetDeskById(deskId);
            var oldDeskId = desk.Id;

            var res = desk.GetReservationById(reservationId);
            res.ChangeReservation(deskId);

            AddEvent(new ReservationChanged(reservationId, oldDeskId, deskId));
        }

        public void AddReservation(DeskId deskId, Reservation reservation)
        {
            var desk = GetDeskById(deskId);

            desk.AddReservation(reservation);
            AddEvent(new DeskReserved(this.Id, deskId, reservation.EmployeeId, reservation.Period));
            
        }

    }
}
