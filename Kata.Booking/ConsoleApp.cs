using Kata.Booking.CQRS.AllBookings;
using Kata.Booking.CQRS.BookRoom;
using Kata.Booking.CQRS.ReadRegistry;
using Kata.Booking.Entities;
using MediatR;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kata.Booking
{
    public class ConsoleApp : IHostedService
    {
        private IMediator mediator;
        public ConsoleApp(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {

            Console.WriteLine("Choose operation");
            Console.WriteLine("1 - All rooms");
            Console.WriteLine("2 - Book a room");
            Console.WriteLine("3 - View Bookings");
            var operation = Console.ReadLine();
            while (operation != null)
            {
                switch (operation)
                {

                    case "1":
                        try
                        {
                            Console.WriteLine("Available Rooms:");
                            var response = await mediator.Send(new GetRoomRequest());
                            foreach (var item in response)
                            {
                                Console.WriteLine("Room number is - " + item.RoomName);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Input information for booking");
                            Console.WriteLine("Enter your ID");
                            var id = Console.ReadLine();
                            Console.WriteLine("Enter Room number to rent:");
                            var roomNumber = Console.ReadLine();
                            Console.WriteLine("When are you starting a rent? Date");
                            var arrivalDate = Console.ReadLine();
                            Console.WriteLine("How many days you will stay?");
                            var daysToStay = Console.ReadLine();
                            Int32.TryParse(id, out int ClientId);
                            DateTime.TryParse(arrivalDate, out DateTime date);
                            Int32.TryParse(daysToStay, out int daysToBook);
                            var booking = await mediator.Send(new BookRoomRequest()
                            {
                                ClientId = ClientId,
                                RoomNumber = roomNumber,
                                ArrivalDate = date,
                                DaysToBook = daysToBook
                            });
                            if (booking == null)
                            {
                                Console.WriteLine("Something's wrong, probably entered a taken room");
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Your Booking:");
                                Console.WriteLine(booking.Client.Id);
                                Console.WriteLine(booking.Room.RoomName);
                                Console.WriteLine(booking.ArrivalDate);
                                Console.WriteLine(booking.DepartureDate);
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "3":
                        try
                        {
                            Console.WriteLine("All bookings");
                            var bookings = await mediator.Send(new BookingsRequest());
                            foreach (var taken in bookings)
                            {
                                Console.WriteLine($"Room with number {taken.Room.RoomName} is taken untill - {taken.DepartureDate}");
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Operation");
                        break;
                }
                Console.WriteLine("New Operation");
                operation = Console.ReadLine();
            }









        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {

        }
    }
}
