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


        public async Task<IEnumerable<AvailableDeskDTO>> Handle(GetAvailiableDesks request, CancellationToken cancellationToken)
             => await _dbContext.Desks
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Where(a => a.Availability == true)
                .Select(d => new AvailableDeskDTO
                (
                 d.Id,
                 d.DeskLocationCode,
                 d.Location.Id
                )).ToListAsync(cancellationToken);

    }
}

