using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneEdit.Data;
using PhoneEdit.Models;

namespace PhoneEdit.Controllers
{
    [Authorize]
    public class PhoneBookController : Controller
    {
        private readonly PhonebookContext _context;

        public PhoneBookController(PhonebookContext context)
        {
            _context = context;
        }

        // GET: PhoneBook
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entries.ToListAsync());
        }

        // GET: PhoneBook/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookEntry = await _context.Entries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookEntry == null)
            {
                return NotFound();
            }

            return View(bookEntry);
        }

        // GET: PhoneBook/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhoneBook/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonnelNumber,Name,Position,Department,LocalPhoneNumber,CityPhoneNumber,Mail,Room")] BookEntry bookEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookEntry);
        }

        // GET: PhoneBook/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookEntry = await _context.Entries.FindAsync(id);
            if (bookEntry == null)
            {
                return NotFound();
            }
            return View(bookEntry);
        }

        // POST: PhoneBook/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonnelNumber,Name,Position,Department,LocalPhoneNumber,CityPhoneNumber,Mail,Room")] BookEntry bookEntry)
        {
            if (id != bookEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookEntryExists(bookEntry.Id))
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
            return View(bookEntry);
        }

        // GET: PhoneBook/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookEntry = await _context.Entries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookEntry == null)
            {
                return NotFound();
            }

            return View(bookEntry);
        }

        // POST: PhoneBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookEntry = await _context.Entries.FindAsync(id);
            _context.Entries.Remove(bookEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookEntryExists(int id)
        {
            return _context.Entries.Any(e => e.Id == id);
        }
    }
}
