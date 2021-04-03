using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Locations.Data;
using Locations.Entities;

namespace Locations.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Countries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Countries.Include(c => c.Continent);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries
                .Include(c => c.Continent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            ViewData["ContinentId"] = new SelectList(_context.Continents, "Id", "Name");
            return View();
        }

        // POST: Countries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContinentId,Name")] Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContinentId"] = new SelectList(_context.Continents, "Id", "Name", country.ContinentId);
            return View(country);
        }

        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            ViewData["ContinentId"] = new SelectList(_context.Continents, "Id", "Name", country.ContinentId);
            return View(country);
        }

        // POST: Countries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Id,ContinentId,Name")] Country country)
        {
            if (id != country.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.Id))
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
            ViewData["ContinentId"] = new SelectList(_context.Continents, "Id", "Name", country.ContinentId);
            return View(country);
        }

        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries
                .Include(c => c.Continent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var country = await _context.Countries.FindAsync(id);
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(byte id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}