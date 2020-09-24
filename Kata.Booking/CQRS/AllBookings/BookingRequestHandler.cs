using Kata.Booking.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kata.Booking.CQRS.AllBookings
{
    public class BookingRequestHandler : BaseHandler<BookingsRequest, IEnumerable<Entities.Booking>>
    {
        public BookingRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override async Task<IEnumerable<Entities.Booking>> Handle(BookingsRequest request, CancellationToken cancellationToken)
        {
           var bookings = bookingRepository.GetBookings();
            if(bookings==null)
            {
                throw new Exception("Bookings list is empty, everything is available");
            }
            var todaysDate = DateTime.Now;
            foreach (var item in bookings.ToList())
            {
                if (item.DepartureDate < todaysDate)
                {
                    bookings.Remove(item);
                    roomsRepository.AddRoom(item.Room.RoomName);
                }
            }
            return bookings;
        }
    }
}
