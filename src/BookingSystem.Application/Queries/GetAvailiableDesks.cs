﻿using BookingSystem.Application.DTO;
using BookingSystem.Domain.ValueObjects.Location;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Queries
{
    public record GetAvailiableDesks(LocationId Guid, DateTime startDate, DateTime endDate, int PageNumber, int PageSize) : IRequest<IEnumerable<AvailableDeskDTO>>;
}
