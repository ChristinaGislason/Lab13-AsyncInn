using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models.Interfaces
{
    interface IHotel
    {       
        // Create
        Task CreateHotel(Hotel hotel);

        // Update
        Task UpdateHotel(Hotel hotel);

        // Delete
        Task DeleteHotel(int id);

        // Read
        Task<List<Hotel>> GetHotels();

        Task<Hotel> GetHotel(int? id);
        
    }
}
