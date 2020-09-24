using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Booking.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        void BookARoom(Entities.Booking booking);
        List<Entities.Booking> GetBookings();
    }
}
