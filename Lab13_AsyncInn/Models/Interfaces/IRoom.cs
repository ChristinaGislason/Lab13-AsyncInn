using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models.Interfaces
{
    public interface IRoom
    {
        // Create
        Task CreateRoom(Room room);

        // Update
        Task UpdateRoom(Room room);

        // Delete
        Task DeleteRoom(int id);

        // Read
        Task<List<Room>> GetRooms();

        Task<Room> GetRoom(int? id);
        Task<bool> RoomsExists(int id);

    }
}
