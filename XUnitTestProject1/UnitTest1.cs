using Lab13_AsyncInn.Data;
using Lab13_AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using System.Linq;


namespace XUnitTestProject1
{
    public class UnitTest1
    {
        /// <summary>
        /// Test to get hotel name
        /// </summary>
        [Fact]
        public void GetsHotelName()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "Async Inn Denver";
            Assert.Equal("Async Inn Denver", hotel.Name);
        }

        /// <summary>
        /// Test to set hotel name
        /// </summary>
        [Fact]
        public void SetsHotelName()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "Async Inn Austin";
            Assert.Equal("Async Inn Austin", hotel.Name);
        }

        /// <summary>
        /// Test to get hotel address
        /// </summary>
        [Fact]
        public void GetHotelAddress()
        {
            Hotel hotel = new Hotel();
            hotel.Address = "123 Fairway Rd";
            Assert.Equal("123 Fairway Rd", hotel.Address);
        }

        /// <summary>
        /// Test to set hotel address
        /// </summary>
        [Fact]
        public void SetHotelAddress()
        {
            Hotel hotel = new Hotel();
            hotel.Address = "300 Derby Dr";
            Assert.Equal("300 Derby Dr", hotel.Address);
        }

        /// <summary>
        /// Test to get hotel phone
        /// </summary>
        [Fact]
        public void GetHotelPhone()
        {
            Hotel hotel = new Hotel();
            hotel.Phone = "914-300-2222";

            Assert.Equal("914-300-2222", hotel.Phone);
        }

        /// <summary>
        /// Test to set hotel phone
        /// </summary>
        [Fact]
        public void SetHotelPhone()
        {
            Hotel hotel = new Hotel();
            hotel.Phone = "222-300-2222";

            Assert.Equal("222-300-2222", hotel.Phone);
        }

        /// <summary>
        /// Test to get amenity name 
        /// </summary>
        [Fact]
        public void GetAmenityName()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "Cable TV";
            Assert.Equal("Cable TV", amenity.Name);
        }

        /// <summary>
        /// Test to set amenity name 
        /// </summary>
        [Fact]
        public void SetAmenityName()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "Jacuzzi";
            Assert.Equal("Jacuzzi", amenity.Name);
        }

        /// <summary>
        /// Test to get hotel room#
        /// </summary>
        [Fact]
        public void GetHotelRoomNumber()
        {
            HotelRoom hotelroom = new HotelRoom();
            hotelroom.RoomNumber = 212;
            Assert.Equal(212, hotelroom.RoomNumber);
        }

        /// <summary>
        /// Test to set hotel room#
        /// </summary>
        [Fact]
        public void SetHotelRoomNumber()
        {
            HotelRoom hotelroom = new HotelRoom();
            hotelroom.RoomNumber = 22;
            Assert.Equal(22, hotelroom.RoomNumber);
        }

        /// <summary>
        /// Test to get hotel room rate
        /// </summary>
        [Fact]
        public void GetHotelRoomRate()
        {
            HotelRoom hotelroom = new HotelRoom();
            hotelroom.Rate = 375;
            Assert.Equal(375, hotelroom.Rate);
        }

        /// <summary>
        /// Test to set hotel room rate
        /// </summary>
        [Fact]
        public void SetHotelRoomRate()
        {
            HotelRoom hotelroom = new HotelRoom();
            hotelroom.Rate = 220;
            Assert.Equal(220, hotelroom.Rate);
        }

        /// <summary>
        /// Get hotel room status if petfriendly 
        /// </summary>
        [Fact]
        public void GetRoomPetFriendlyStatus()
        {
            HotelRoom hotelroom = new HotelRoom();
            hotelroom.PetFriendly = true;
            Assert.True(hotelroom.PetFriendly);
        }

        /// <summary>
        /// Set hotel room status if petfriendly 
        /// </summary>
        [Fact]
        public void SetRoomPetFriendlyStatus()
        {
            HotelRoom hotelroom = new HotelRoom();
            hotelroom.PetFriendly = false;
            Assert.False(hotelroom.PetFriendly);
        }

        /// <summary>
        /// Test to get room name
        /// </summary>
        [Fact]
        public void GetRoomName()
        {
            Room room = new Room();
            room.Name = "Ultra Super Deluxe";
            Assert.Equal("Ultra Super Deluxe", room.Name);
        }

        /// <summary>
        /// Test to set room name
        /// </summary>
        [Fact]
        public void SetRoomName()
        {
            Room room = new Room();
            room.Name = "SuperDuper Luxe";
            Assert.Equal("SuperDuper Luxe", room.Name);
        }
        
        /// <summary>
        /// Test to create and read hotel table
        /// </summary>
        [Fact]
        public async void CreateandReadHotelDB()
        {
            // Create mini database environment for testing 
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Create new instance of hotel and assign name to hotel. Add it to the hotel database and save changes.
                Hotel hotel = new Hotel();
                hotel.Name = "Async San Francisco";
                context.Hotels.Add(hotel);
                context.SaveChanges();
          
                // Create variable; return the first hotel whose name matches the hotel name above OR the default
                var testHotel = await context.Hotels.FirstOrDefaultAsync(x => x.Name == hotel.Name);

                // Test to see that the hotel name matches the recently added hotel in the hotel table
                Assert.Equal("Async San Francisco", testHotel.Name);
            }

        }

        /// <summary>
        /// Test to create and read amenity table
        /// </summary>
        [Fact]
        public async void CreateandReadAmenityDB()
        {
            // Create mini database environment for testing 
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateAmenity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Create new instance of amenity and assign name. Add it to the amenity database and save changes.
                Amenities amenity = new Amenities();
                amenity.Name = "scented candles";
                context.Amenities.Add(amenity);
                context.SaveChanges();

                // Create variable; return the first amenity whose name matches the amenity name above OR the default
                var testAmenity = await context.Amenities.FirstOrDefaultAsync(x => x.Name == amenity.Name);

                // Test to see that the hotel name matches the recently added hotel in the hotel table
                Assert.Equal("scented candles", testAmenity.Name);
            }
        }

        /// <summary>
        /// Test to create and read hotelroom table
        /// </summary>
        [Fact]
        public async void CreateandReadHotelRoomDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("CreateHotelRoom")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                HotelRoom hotelroom = new HotelRoom();
                hotelroom.RoomNumber = 515;

                context.HotelRooms.Add(hotelroom);
                await context.SaveChangesAsync();

                var testHotelRoom = await context.HotelRooms.FirstOrDefaultAsync(x => x.RoomNumber == hotelroom.RoomNumber);

                Assert.Equal(515, hotelroom.RoomNumber);
            }
        }

        /// <summary>
        /// Test to create and read from Room Amenities table
        /// </summary>
        [Fact]
        public async void CreateAndReadRoomAmenitiesDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("CreateRoomAmenity")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amenity = new Amenities();
                amenity.Name = "Humidifier";

                RoomAmenities roomAmenities = new RoomAmenities();
                roomAmenities.Amenities = amenity;

                context.RoomAmenities.Add(roomAmenities);
                await context.SaveChangesAsync();

                var testAmenities = await context.Amenities.FirstOrDefaultAsync(x => x.Name == amenity.Name);

                Assert.Equal("Humidifier", amenity.Name);
            }
        }

        /// <summary>
        /// Test to update Amenity table
        /// </summary>
        [Fact]
        public async void UpdateAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("UpdateAmenity")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amenity = new Amenities();
                amenity.Name = "Ping pong table";
                context.Amenities.Add(amenity);
                await context.SaveChangesAsync();

                amenity.Name = "Ping pong table";
                context.Amenities.Update(amenity);
                await context.SaveChangesAsync();

                var amenities = await context.Amenities.FirstOrDefaultAsync(x => x.Name == amenity.Name);

                Assert.Equal("Ping pong table", amenities.Name);
            }
        }

        /// <summary>
        /// Test to update hotel table
        /// </summary>
        [Fact]
        public async void UpdateHotel()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("UpdateHotel")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.Name = "Async Malibu";
                context.Hotels.Add(hotel);
                await context.SaveChangesAsync();

                hotel.Name = "Async Malibu";
                context.Hotels.Update(hotel);
                await context.SaveChangesAsync();

                var testHotel = await context.Hotels.FirstOrDefaultAsync(x => x.Name == hotel.Name);

                Assert.Equal("Async Malibu", hotel.Name);
            }
        }

    }
}
