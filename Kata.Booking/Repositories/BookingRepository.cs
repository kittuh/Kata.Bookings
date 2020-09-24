using Kata.Booking.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Booking.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        List<Entities.Booking> Bookings = new List<Entities.Booking>();
        public void BookARoom(Entities.Booking booking)
        {
            Bookings.Add(booking);
        }

        public List<Entities.Booking> GetBookings()
        {
            return Bookings;
        }
    }
}
