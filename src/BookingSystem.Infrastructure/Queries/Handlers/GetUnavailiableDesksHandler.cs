﻿using BookingSystem.Application.DTO;
using BookingSystem.Application.Queries;
using BookingSystem.Infrastructure.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Queries.Handlers
{
    internal sealed class GetUnavailiableDesksHandler
    {
        private readonly AppDbContext _dbContext;
        public GetUnavailiableDesksHandler(AppDbContext context)
            => _dbContext = context;

        public async Task<IEnumerable<UnavailableDeskDTO>> Handle(GetUnavailiableDesks request, CancellationToken cancellationToken)
                => await _dbContext.Desks
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Where(a => a.Availability == false)
                .Select(d => new UnavailableDeskDTO
                (
                    d.Id,
                    d.DeskLocationCode,
                    d.Location.Id
                )).ToListAsync(cancellationToken);

    }
}
