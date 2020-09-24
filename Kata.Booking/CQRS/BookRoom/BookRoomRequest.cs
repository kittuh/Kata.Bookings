using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Booking.CQRS.BookRoom
{
    public class BookRoomRequest : IRequest<Entities.Booking>
    {
        public int ClientId { get; set; }
        public string RoomNumber { get; set;}
        public DateTime ArrivalDate { get; set; }
        public int DaysToBook { get; set; }
    }
}
