using Kata.Booking.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Booking.Repositories.Interfaces
{
    public interface IRoomsRepository
    {
        IEnumerable<Room> GetRooms();
        Room GetRoom(string number);
        void DeleteRoom(string number);
        void AddRoom(string number);
    }
}
