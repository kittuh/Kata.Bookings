using Kata.Booking.Entities;
using Kata.Booking.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kata.Booking.CQRS.BookRoom
{
    public class BookRoomRequestHandler : BaseHandler<BookRoomRequest, Entities.Booking>
    {
        public BookRoomRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override async Task<Entities.Booking> Handle(BookRoomRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new Exception("Entered wrong information");
            if (request.ArrivalDate < DateTime.Now.AddDays(-1))
                throw new Exception("Arrival date must be today's date or future");
            var booking = new Entities.Booking()
            {
                Client = new Client()
                {
                    Id = request.ClientId
                },
                Room = new Room()
                {
                    RoomName = request.RoomNumber
                },
                ArrivalDate = request.ArrivalDate,
                DepartureDate = request.ArrivalDate.AddDays(request.DaysToBook)
            };
            if (roomsRepository.GetRoom(request.RoomNumber) != null)
            {
                bookingRepository.BookARoom(booking);
                roomsRepository.DeleteRoom(request.RoomNumber);
                return booking;
            }
            else throw new Exception("Cant find room with this number");

        }
    }
}
