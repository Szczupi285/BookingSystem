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
                    desk.AddReservation(new Reservation(res.Id, new ReservationPeriod(res.StartDate, res.EndDate, new DateTimeProvider()), DeskModel.Id, Guid.Parse(res.User.Id)));
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
                Desks = new List<DeskModel>()
            };
            foreach(var desk in location.Desks)
            {
                var deskModel = new DeskModel
                {
                    Id = desk.Id.Value,
                    DeskLocationCode = desk.LocationCode,
                    Availability = desk.Availability == AvailabilityEnum.Available ? true : false,
                    Location = loc,
                    Reservations = new List<ReservationModel>()
                };
                foreach (var res in desk.GetReservations())
                {
                    var resModel = new ReservationModel
                    {
                        Id = res.Id.Value,
                        StartDate = res.Period.StartDate,
                        EndDate = res.Period.EndDate,
                        Desk = deskModel,
                        UserId = res.EmployeeId.Value.ToString()
                    };
                    deskModel.Reservations.Add(resModel);
                }
                loc.Desks.Add(deskModel);
            }

            return loc;
        }
    }
}
