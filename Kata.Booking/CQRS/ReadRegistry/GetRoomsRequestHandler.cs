using Kata.Booking.Entities;
using Kata.Booking.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kata.Booking.CQRS.ReadRegistry
{
    public class GetRoomsRequestHandler : BaseHandler<GetRoomRequest, IEnumerable<Room>>
    {
        public GetRoomsRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override async Task<IEnumerable<Room>> Handle(GetRoomRequest request, CancellationToken cancellationToken)
        {
            return roomsRepository.GetRooms();
        }
    }
}
