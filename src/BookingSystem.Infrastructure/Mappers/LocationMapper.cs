using BookingSystem.Domain.Consts;
using BookingSystem.Domain.DateTimeProvider;
using BookingSystem.Domain.Entities;
using BookingSystem.Domain.ValueObjects.Desk;
using BookingSystem.Domain.ValueObjects.Location;
using BookingSystem.Domain.ValueObjects.Reservation;
using BookingSystem.Infrastructure.EF.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Mappers
{
    

    // temporary mapper
    internal static class LocationMapper
    {
        internal static Location MapToLocation(LocationModel locationModel)
        {
            var loc = new  Location
                (
                locationModel.Id,
                locationModel.City,
                locationModel.Street,
                locationModel.HouseNumber,
                locationModel.FlatNumber,
                locationModel.PostalCode
                );

            foreach(var DeskModel in locationModel.Desks)
            {
                var desk = new Desk(
                new DeskId(DeskModel.Id),
                new DeskLocationCode(DeskModel.DeskLocationCode),
                new LocationId(DeskModel.Location.Id),
                DeskModel.Availability ? AvailabilityEnum.Available : AvailabilityEnum.Unavailable);

                loc.AddDesk(desk);


                foreach (var res in DeskModel.Reservations)
                {
                    var reserv = new Reservation(res.Id, new ReservationPeriod(res.StartDate, res.EndDate, new DateTimeProvider(), true), DeskModel.Id, Guid.Parse(res.User.Id));
                    desk._reservations.Add(reserv);
                }
            }
            return loc;
        }
        internal static LocationModel MapToLocationModel(Location location)
        {
            var loc = new LocationModel
            {
                Id = location.Id,
                City = location.CityName,
                Street = location.StreetName,
                HouseNumber = location.HouseNumber,
                FlatNumber = location.FlatNumber,
                PostalCode = location.PostalCode,
                Desks = location.Desks.Select(desk => new DeskModel
                {
                    Id = desk.Id.Value,
                    DeskLocationCode = desk.LocationCode,
                    Availability = desk.Availability == AvailabilityEnum.Available ? true : false,
                    LocationId = location.Id, 
                    Reservations = desk.GetReservations().Select(res => new ReservationModel
                    {
                        Id = res.Id.Value,
                        StartDate = res.Period.StartDate,
                        EndDate = res.Period.EndDate,
                        UserId = res.EmployeeId.Value.ToString(),
                        DeskId = desk.Id.Value 
                    }).ToList()
                }).ToList()
            };

            return loc;
        }
        internal static DeskModel MapToDeskModel(Desk desk)
        {
            var deskModel = new DeskModel
            {
                Id = desk.Id,
                DeskLocationCode = desk.LocationCode,
                LocationId = desk.LocationId,
                Availability = AvailabilityEnum.Available == desk.Availability ? true : false,
            };
            return deskModel;
        }
    }
}
