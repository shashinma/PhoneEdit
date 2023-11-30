// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Authorization.Infrastructure;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using PhoneEdit.Data;
// using PhoneEdit.Models;
// using X.PagedList;
//
// namespace PhoneEdit.Controllers;
//
// [Authorize]
// public class PhoneBookController : Controller
// {
//     
//     private readonly PhonebookContext _context;
//     private readonly ILogger<PhoneBookController> _logger;
//     
//     public PhoneBookController(PhonebookContext context, ILogger<PhoneBookController> logger)
//     {
//         _context = context;
//         _logger = logger;
//     }
//     
//     // GET: PhoneBook
//     [AllowAnonymous]
//     public async Task<IActionResult> Index(string currentFilter, string searchString, int? cPage)
//     {
//         if (searchString != null)
//         {
//             cPage = 1;
//         }
//         else
//         {
//             searchString = currentFilter;
//         }
//         
//         ViewBag.CurrentFilter = searchString;
//         
//         var entries = _context.Entries.Select(e => e);
//         
//         if (!string.IsNullOrEmpty(searchString))
//         {
//             entries = entries.Where(e => e.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase));
//         }
//         
//         entries = entries.OrderBy(e => e.Name);
//         
//         int pageSize = 25;
//         int pageNumber = (cPage ?? 1);
//         
//         return View((await entries.ToListAsync()).ToPagedList(pageNumber, pageSize));
//     }
//
//     // GET: PhoneBook/Details/5
//     public async Task<IActionResult> Details(int? id)
//     {
//         if (id == null)
//         {
//             return NotFound();
//         }
//
//         var bookEntry = await _context.Entries
//             .FirstOrDefaultAsync(m => m.Id == id);
//         if (bookEntry == null)
//         {
//             return NotFound();
//         }
//
//         return View(bookEntry);
//     }
//
//     // GET: PhoneBook/Create
//     public IActionResult Create()
//     {
//         return View();
//     }
//
//     // POST: PhoneBook/Create
//     // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//     // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//     [HttpPost]
//     [ValidateAntiForgeryToken]
//     public async Task<IActionResult> Create(
//         [Bind("Id,PersonnelNumber,Name,Position,Department,LocalPhoneNumber,CityPhoneNumber,Mail,Room")]
//         BookEntry bookEntry)
//     {
//         if (!VerifyPersonnelNumber(bookEntry))
//         {
//             ModelState.AddModelError(nameof(bookEntry.PersonnelNumber), "Табельный номер уже существует");
//         }
//
//         if (ModelState.IsValid)
//         {
//             _context.Add(bookEntry);
//             await _context.SaveChangesAsync();
//             return RedirectToAction(nameof(Index));
//         }
//
//         return View(bookEntry);
//     }
//
//     // GET: PhoneBook/Edit/5
//     public async Task<IActionResult> Edit(int? id)
//     {
//         if (id == null)
//         {
//             return NotFound();
//         }
//
//         var bookEntry = await _context.Entries.FindAsync(id);
//         if (bookEntry == null)
//         {
//             return NotFound();
//         }
//
//         return View(bookEntry);
//     }
//
//     // POST: PhoneBook/Edit/5
//     // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//     // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//     [HttpPost]
//     [ValidateAntiForgeryToken]
//     public async Task<IActionResult> Edit(int id,
//         [Bind("Id,PersonnelNumber,Name,Position,Department,LocalPhoneNumber,CityPhoneNumber,Mail,Room, Status")]
//         BookEntry bookEntry)
//     {
//         if (id != bookEntry.Id)
//         {
//             return NotFound();
//         }
//
//         if (!VerifyPersonnelNumber(bookEntry))
//         {
//             ModelState.AddModelError(nameof(bookEntry.PersonnelNumber), "Табельный номер уже существует");
//         }
//
//         if (ModelState.IsValid)
//         {
//             try
//             {
//                 _context.Update(bookEntry);
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!BookEntryExists(bookEntry.Id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }
//
//             return RedirectToAction(nameof(Index));
//         }
//
//         return View(bookEntry);
//     }
//
//     // GET: PhoneBook/Delete/5
//     public async Task<IActionResult> Delete(int? id)
//     {
//         if (id == null)
//         {
//             return NotFound();
//         }
//
//         var bookEntry = await _context.Entries
//             .FirstOrDefaultAsync(m => m.Id == id);
//         if (bookEntry == null)
//         {
//             return NotFound();
//         }
//
//         return View(bookEntry);
//     }
//
//     // POST: PhoneBook/Delete/5
//     [HttpPost, ActionName("Delete")]
//     [ValidateAntiForgeryToken]
//     public async Task<IActionResult> DeleteConfirmed(int id)
//     {
//         var bookEntry = await _context.Entries.FindAsync(id);
//         _context.Entries.Remove(bookEntry);
//         await _context.SaveChangesAsync();
//         return RedirectToAction(nameof(Index));
//     }
//
//     private bool BookEntryExists(int id)
//     {
//         return _context.Entries.Any(e => e.Id == id);
//     }
//
//
//     // Valid only if personnelNumber is unique
//     private bool VerifyPersonnelNumber(string personnelNumber, int id)
//     {
//         var entry = _context.Entries.AsNoTracking().FirstOrDefault(e => e.PersonnelNumber == personnelNumber);
//         return (entry == null || entry.Id == id);
//     }
//
//     private bool VerifyPersonnelNumber(BookEntry entry)
//     {
//         return VerifyPersonnelNumber(entry.PersonnelNumber, entry.Id);
//     }
//
//     [AcceptVerbs("Get", "Post")]
//     public IActionResult RemoteVerifyPersonnelNumber(string personnelNumber, int id)
//     {
//         if (VerifyPersonnelNumber(personnelNumber, id))
//         {
//             return Json(true);
//         }
//
//         return Json($"Табельный номер {personnelNumber} уже существует");
//     }
// }




//
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using PhoneEdit.Data;
// using PhoneEdit.Models;
// using PhoneEdit.Services;
// using System;
// using System.Linq;
// using System.Threading.Tasks;
// using X.PagedList;
//
// public class PhoneBookController : Controller
// {
//     private readonly PhonebookContext _context;
//     private readonly ILogger<PhoneBookController> _logger;
//
//     public PhoneBookController(PhonebookContext context, ILogger<PhoneBookController> logger)
//     {
//         _context = context;
//         _logger = logger;
//     }
//
//     public async Task<IActionResult> Index(string currentFilter, string searchString, int? cPage)
//     {
//         try
//         {
//             // Получите все записи из базы данных
//             var entries = _context.Entries.Select(e => e);
//
//             // Примените фильтр поиска, если он указан
//             if (!string.IsNullOrEmpty(searchString))
//             {
//                 entries = entries.Where(e => 
//                     e.Name.ToString()
//                         .Contains(searchString, StringComparison.OrdinalIgnoreCase));
//             }
//
//             // Отсортируйте записи
//             entries = entries.OrderBy(e => e.Name);
//
//             // Установите размер страницы
//             int pageSize = 25;
//             int pageNumber = cPage ?? 1;
//
//             // Создайте экземпляр IPagedList
//             var pagedEntries = await entries.ToPagedListAsync(pageNumber, pageSize);
//
//             return View(pagedEntries);
//         }
//         catch (Exception ex)
//         {
//             _logger.LogError(ex, "An error occurred in the Index action of PhoneBookController");
//             throw; // Либо обработайте ошибку здесь, либо перевыбросьте исключение
//         }
//     }
// }


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
using X.PagedList;

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
        public IActionResult Index(string? searchString, string? currentFilter, int? cPage)
        {
            if (searchString != null)
            {
                cPage = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var entries = _context.Entries.Select(e => e).AsEnumerable();

            if (!string.IsNullOrEmpty(searchString))
            {
                entries = entries.Where(e => e.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            entries = entries.OrderBy(e => e.Name);

            int pageSize = 25;
            int pageNumber = (cPage ?? 1);

            return View(entries.AsQueryable().ToPagedList(pageNumber, pageSize));
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
            if (!VerifyPersonnelNumber(bookEntry))
            {
                ModelState.AddModelError(nameof(bookEntry.PersonnelNumber), "Табельный номер уже существует");
            }
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonnelNumber,Name,Position,Department,LocalPhoneNumber,CityPhoneNumber,Mail,Room, Status")] BookEntry bookEntry)
        {
            if (id != bookEntry.Id)
            {
                return NotFound();
            }

            if (!VerifyPersonnelNumber(bookEntry))
            {
                ModelState.AddModelError(nameof(bookEntry.PersonnelNumber), "Табельный номер уже существует");
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


        // Valid only if personnelNumber is unique
        private bool VerifyPersonnelNumber(string personnelNumber, int id)
        {
            var entry = _context.Entries.AsNoTracking().FirstOrDefault(e => e.PersonnelNumber == personnelNumber);
            return (entry == null || entry.Id == id);
        }

        private bool VerifyPersonnelNumber(BookEntry entry)
        {
            return VerifyPersonnelNumber(entry.PersonnelNumber, entry.Id);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult RemoteVerifyPersonnelNumber(string personnelNumber, int id)
        {
            if(VerifyPersonnelNumber(personnelNumber, id))
            {
                return Json(true);
            }
            return Json($"Табельный номер {personnelNumber} уже существует");
        }
    }
}
