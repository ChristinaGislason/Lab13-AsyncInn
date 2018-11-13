using Lab13_AsyncInn.Models;
using System;
using Xunit;

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
    }
}
