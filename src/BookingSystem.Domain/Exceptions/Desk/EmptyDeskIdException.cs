﻿using BookingSystem.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Exceptions.Desk
{
    public class EmptyDeskIdException : BookingSystemException
    {
        public EmptyDeskIdException() : base("Desk Id cannot be empty")
        {
        }
    }
}
