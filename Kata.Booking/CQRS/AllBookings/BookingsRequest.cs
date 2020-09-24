using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Booking.CQRS.AllBookings
{
    public class BookingsRequest : IRequest<IEnumerable<Entities.Booking>>
    {
    }
}
