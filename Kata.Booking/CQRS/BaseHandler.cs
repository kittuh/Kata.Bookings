using Kata.Booking.Repositories;
using Kata.Booking.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kata.Booking.CQRS
{
    public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly IBookingRepository bookingRepository;
        protected readonly IRoomsRepository roomsRepository;


        public BaseHandler(IServiceProvider serviceProvider)
        {
            bookingRepository = serviceProvider.GetService<IBookingRepository>();
            roomsRepository = serviceProvider.GetService<IRoomsRepository>();
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken = default);
    }

}
