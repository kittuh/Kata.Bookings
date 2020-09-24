using Kata.Booking.Entities;
using Kata.Booking.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Booking.Repositories
{
    public class RoomRepository : IRoomsRepository
    {
        public List<Room> Rooms = new List<Room>() 
        {

            new Room() { RoomName ="415" },
            new Room() { RoomName ="426" },
            new Room() { RoomName ="437" },
            new Room() { RoomName ="320" },
            new Room() { RoomName ="330" },
            new Room() { RoomName ="340" },
        };

        public void AddRoom(string number)
        {
            Rooms.Add(new Room() { RoomName = number });
        }

        public void DeleteRoom(string number)
        {
            Rooms.Remove(GetRoom(number));
        }
        public Room GetRoom(string number)
        {
            return Rooms.Find(x => x.RoomName == number);
        }
        public IEnumerable<Room> GetRooms()
        {
            return Rooms;
        }
    }
}
