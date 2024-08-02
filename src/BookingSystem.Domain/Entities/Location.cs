using BookingSystem.Domain.Exceptions.Desk;
using BookingSystem.Domain.Exceptions.Location;
using BookingSystem.Domain.ValueObjects.Desk;
using BookingSystem.Domain.ValueObjects.Location;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Domain.Entities
{
    public class Location
    {
        public LocationId Id { get; }
        public CityName CityName { get; private set; }
        public StreetName StreetName { get; private set; }
        public HouseNumber HouseNumber { get; private set; }
        public FlatNumber? FlatNumber { get; private set; }
        public PostalCode PostalCode { get; private set; }
        public HashSet<Desk> Desks { get; private set;}

        public Location(LocationId id, CityName cityName, StreetName streetName, 
            HouseNumber houseNumber, FlatNumber? flatNumber, PostalCode postalCode)
        {
            Id = id;
            CityName = cityName;
            StreetName = streetName;
            HouseNumber = houseNumber;
            FlatNumber = flatNumber;
            PostalCode = postalCode;
            Desks = new HashSet<Desk>();
        }

        public void AddDesk(Desk desk) 
        { 
            if(desk is null)
                throw new DeskCannotBeNullException();
            Desks.Add(desk);
        }
        public void RemoveDesk(DeskId deskId)
        {
            var desk = Desks.FirstOrDefault(d => d.Id == deskId);
            if (desk is null)
                throw new DeskNotFoundException(deskId);
            else if(desk.HaveFutureReservations())
                throw new CannotRemoveReservedDeskException();
            
            Desks.Remove(desk);
        }
        public void MakeDeskUnavailiable(DeskId deskId)
        {
            var desk = Desks.FirstOrDefault(d => d.Id == deskId) ?? throw new DeskNotFoundException(deskId);
            desk.MakeUnavailiable();
        }
        public void MakeDeskAvailiable(DeskId deskId)
        {
            var desk = Desks.FirstOrDefault(d => d.Id == deskId) ?? throw new DeskNotFoundException(deskId);
            desk.MakeAvailiable();
        }

    }
}
