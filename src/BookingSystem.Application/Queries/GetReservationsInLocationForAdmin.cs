using BookingSystem.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Queries
{
    public record GetReservationsInLocationForAdmin : IRequest<IEnumerable<AdminReservationDetailsDTO>>;
}
