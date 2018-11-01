using Lab13_AsyncInn.Data;
using Lab13_AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models.Services
{
    public class HotelService : IHotel
    {
        private AsyncInnDbContext _context;

        public HotelService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<List<Hotel>> GetHotels()
        {
            return await _context.Hotel.ToListAsync();
        }
    }
}
