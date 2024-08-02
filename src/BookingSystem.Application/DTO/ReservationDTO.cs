﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.DTO
{
    public record ReservationDTO(Guid Id, Guid DeskId, DateTime StartDate, DateTime EndDate);
}
