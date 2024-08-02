﻿using BookingSystem.Domain.Consts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Commands
{
    public record AddDesk(Guid locationId, string LocationCode) : IRequest;
}
