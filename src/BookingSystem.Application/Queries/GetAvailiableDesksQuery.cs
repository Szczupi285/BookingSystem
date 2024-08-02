using BookingSystem.Application.DTO;
using BookingSystem.Domain.ValueObjects.Location;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Queries
{
    public record GetAvailiableDesksQuery(LocationId Guid) : IRequest<IEnumerable<AvailableDeskDTO>>;
}
