﻿using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Reservation
{
    public class ReservationCannotEndBeforeItStartsException : BookingSystemException
    {
        public ReservationCannotEndBeforeItStartsException(DateTime startDate, DateTime endDate) : base($"EndDate: {endDate} cannot be before startDate {startDate}")
        {
        }
    }
}
