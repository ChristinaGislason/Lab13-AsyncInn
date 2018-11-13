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
    }
}
