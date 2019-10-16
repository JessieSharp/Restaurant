using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public int TableSize { get; set; }
        public string Date { get; set; }
        public bool IsDeleted { get; set; } //i think even deleted reservations should be still in database because in any law accident we have a full docs
    }

}
