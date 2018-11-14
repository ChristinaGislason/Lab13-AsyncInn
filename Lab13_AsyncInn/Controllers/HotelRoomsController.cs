using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab13_AsyncInn.Data;
using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Models.Interfaces;

namespace Lab13_AsyncInn.Controllers
{
    public class HotelRoomsController : Controller
    {
        private readonly AsyncInnDbContext _context;
        private readonly IHotel _hotel;
        private readonly IRoom _room;

        //Hotel Rooms constructor-- brings in code into a class 
        public HotelRoomsController(AsyncInnDbContext context, IHotel hotel, IRoom room)
        {
            _context = context;
            _hotel = hotel;
            _room = room;         
        }

        // GET: HotelRooms
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.HotelRooms.Include(h => h.Hotel).Include(h => h.Room);
            return View(await asyncInnDbContext.ToListAsync());
        }

        // GET: HotelRooms/Details/5
        public async Task<IActionResult> Details(int? hotelID, int? roomNumber)
        {
            if (hotelID == null || roomNumber == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms
                .Include(h => h.Hotel)
                .FirstOrDefaultAsync(m => m.HotelID == hotelID && m.RoomNumber == roomNumber);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // GET: HotelRooms/Create
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name");

            return View();
        }

        // POST: HotelRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "ID", hotelRoom.RoomID);

            return View(hotelRoom);
        }

        // GET: HotelRooms/Edit/5
        public async Task<IActionResult> Edit(int? hotelID, int roomNumber)
        {
            if (hotelID == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms.FindAsync(hotelID, roomNumber);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomID);

            return View(hotelRoom);
        }

        // POST: HotelRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int hotelID, int roomNumber, [Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (hotelID != hotelRoom.HotelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRoomExists(hotelRoom.HotelID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "ID", hotelRoom.RoomID);
            return View(hotelRoom);
            
        }

        // GET: HotelRooms/Delete/5
        public async Task<IActionResult> Delete(int? hotelID, int? roomNumber)
        {
            if (hotelID == null || roomNumber == null)
            {
                return NotFound();
            }

            
       
            var hotelRoom = await _context.HotelRooms
                .Include(h => h.Hotel).Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelID == hotelID && m.RoomNumber == roomNumber);

            if (hotelRoom == null)
            {
                return NotFound();
            }
            //return View();
            return View(hotelRoom);
        }

        // POST: HotelRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int HotelID, int RoomNumber)
        {
            
            var hotelRoom = await _context.HotelRooms.FindAsync(HotelID, RoomNumber);
            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelRoomExists(int id)
        {
            return _context.HotelRooms.Any(e => e.HotelID == id);
        }
    }
}
