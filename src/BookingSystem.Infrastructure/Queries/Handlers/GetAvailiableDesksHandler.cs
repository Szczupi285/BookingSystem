using BookingSystem.Application.DTO;
using BookingSystem.Application.Queries;
using BookingSystem.Infrastructure.EF;
using BookingSystem.Infrastructure.EF.DTO;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Queries.Handlers
{
    internal sealed class GetAvailiableDesksHandler : IRequestHandler<GetAvailiableDesks, IEnumerable<AvailableDeskDTO>>
    {
        private readonly AppDbContext _dbContext;
        public GetAvailiableDesksHandler(AppDbContext context)
            => _dbContext = context;


        // checks if availiability is set to true and not one reservation overlaps
        public async Task<IEnumerable<AvailableDeskDTO>> Handle(GetAvailiableDesks request, CancellationToken cancellationToken)
             => await _dbContext.Desks
                .Where(d => d.Location.Id == request.LocationId &&
                    d.Availability == true &&
                !d.Reservations.Any(r =>
                    request.StartDate <= r.EndDate && r.StartDate < request.EndDate))
                .Take(request.PageSize)
                .Select(d => new AvailableDeskDTO
                (
                 d.Id,
                 d.DeskLocationCode,
                 d.Location.Id
                )).ToListAsync(cancellationToken);

    }
}

