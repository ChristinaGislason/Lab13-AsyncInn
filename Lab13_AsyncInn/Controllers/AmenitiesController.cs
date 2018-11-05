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
    public class AmenitiesController : Controller
    {
        private IAmenities _amenities { get; set; }

        public AmenitiesController(IAmenities context)
        {
            _amenities = context;
        }

        // GET: Amenities
        public async Task<IActionResult> Index()
        {
            return View(await _amenities.GetAmenities());
            //return View(await _context.Amenities.ToListAsync());
        }

        // GET: Amenities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var amenities = await _amenities.GetAmenity(id);
            //var amenities = await _context.Amenities
             //   .FirstOrDefaultAsync(m => m.ID == id);
            if (amenities == null)
            {
                return NotFound();
            }

            return View(amenities);
        }

        // GET: Amenities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Amenities amenities)
        {
            if (ModelState.IsValid)
            {
                await _amenities.CreateAmenity(amenities);
                //_context.Add(amenities);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(amenities);
        }

        // GET: Amenities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var amenities = await _amenities.GetAmenity(id);
            //var amenities = await _context.Amenities.FindAsync(id);
            if (amenities == null)
            {
                return NotFound();
            }
            return View(amenities);
        }

        // POST: Amenities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Amenities amenities)
        {
            if (id != amenities.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _amenities.UpdateAmenity(amenities);
                    //_context.Update(amenities);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _amenities.AmenitiesExists(amenities.ID))
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
            return View(amenities);
        }

        // GET: Amenities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var amenities = await _amenities.GetAmenity(id);
            //var amenities = await _context.Amenities
             //   .FirstOrDefaultAsync(m => m.ID == id);
            if (amenities == null)
            {
                return NotFound();
            }

            return View(amenities);
        }

        // POST: Amenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _amenities.DeleteAmenity(id);
            //var amenities = await _context.Amenities.FindAsync(id);
            //_context.Amenities.Remove(amenities);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
