using Lab13_AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>().HasKey(
                hr => new { hr.HotelID, hr.RoomNumber });
            modelBuilder.Entity<RoomAmenities>().HasKey(
               ra => new { ra.AmenitiesID, ra.RoomID });

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Async Seattle",
                    Address = "111 Alki Way",
                    Phone = 9988
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Async Bellevue",
                    Address = "123 Main St.",
                    Phone = 8877
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Async Portland",
                    Address = "2244 Talbot Rd.",
                    Phone = 8585
                },
                new Hotel
                {
                    ID = 4,
                    Name = "Async Vancouver",
                    Address = "3003 Ocean Dr.",
                    Phone = 5500
                },
                new Hotel
                {
                    ID = 5,
                    Name = "Async Victoria",
                    Address = "688 Blanshard St.",
                    Phone = 4231
                }
                );

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Basic",
                    Layout = Layout.Studio
                },
                new Room
                {
                    ID = 2,
                    Name = "Standard",
                    Layout = Layout.Studio
                },
                new Room
                {
                    ID = 3,
                    Name = "Deluxe",
                    Layout = Layout.OneBedroom
                },
                new Room
                {
                    ID = 4,
                    Name = "Ultra-Deluxe",
                    Layout = Layout.OneBedroom
                },
                new Room
                {
                    ID = 5,
                    Name = "Superior",
                    Layout = Layout.TwoBedroom
                },
                new Room
                {
                    ID = 6,
                    Name = "Presidential Suite",
                    Layout = Layout.TwoBedroom
                }
                );


            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "coffeemaker",
                },
                new Amenities
                {
                    ID = 2,
                    Name = "wifi",
                },
                new Amenities
                {
                    ID = 3,
                    Name = "hot tub",
                },
                new Amenities
                {
                    ID = 4,
                    Name = "television",
                },
                new Amenities
                {
                    ID = 5,
                    Name = "minibar",
                }
                );
        }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<HotelRoom> HotelRooms { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomAmenities> RoomAmenities { get; set; }

        public DbSet<Amenities> Amenities { get; set; }

    }
}
