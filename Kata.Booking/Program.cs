using Kata.Booking.CQRS.ReadRegistry;
using Kata.Booking.Repositories;
using Kata.Booking.Repositories.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Kata.Booking
{

    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args);

            await hostBuilder.RunConsoleAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostingContext, services) =>
                {
                    services.AddMediatR(Assembly.GetExecutingAssembly());
                    services.AddSingleton<IHostedService, ConsoleApp>();
                    services.AddScoped<IRoomsRepository, RoomRepository>();
                    services.AddScoped<IBookingRepository, BookingRepository>();
                });
    }
}
