using Kata.Booking.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Booking.CQRS.ReadRegistry
{
    public class GetRoomRequest : IRequest<IEnumerable<Room>>
    {
    }
}
