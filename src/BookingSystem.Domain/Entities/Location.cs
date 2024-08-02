using BookingSystem.Domain.Exceptions.Desk;
using BookingSystem.Domain.ValueObjects.Desk;
using BookingSystem.Domain.ValueObjects.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

       
       

    }
}
