using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.EF.Models
{
    public class DeskModel
    {
        public Guid Id { get; set; }   
        public string DeskLocationCode { get; set; }
        public LocationModel Location { get; set; }
        public Guid LocationId { get; set; }
        public bool Availability { get; set; }
        public ICollection<ReservationModel> Reservations { get; set; }
    }
}
