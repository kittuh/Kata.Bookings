using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Booking.Entities
{
    public class Booking
    {
        public Client Client { get; set; }
        public Room Room { get; set; }
        public DateTime ArrivalDate { get; set;}
        public DateTime DepartureDate { get; set; }
    }
}
