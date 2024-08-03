using MediatR.NotificationPublishers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.EF.Models
{
    public class LocationModel
    {
        public Guid Id { get; set; }   
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string FlatNumber { get; set; }
        public string PostalCode { get; set; }
        public ICollection<DeskModel> Desks { get; set; }
        
    }
}
