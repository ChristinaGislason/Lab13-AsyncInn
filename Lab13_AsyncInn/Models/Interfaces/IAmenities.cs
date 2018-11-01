using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models.Interfaces
{
    interface IAmenities
    {
        // Create
        Task CreateAmenity(Amenities amenity);

        // Update
        Task UpdateAmenity(Amenities amenity);

        // Delete
        Task DeleteAmenity(int id);

        // Read
        Task<List<Amenities>> GetAmenities();

        Task<Amenities> GetAmenity(int? id);
    }
}
