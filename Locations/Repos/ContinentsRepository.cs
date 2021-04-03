using System.Collections.Generic;
using System.Linq;
using Locations.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Locations.Repos
{
    public class ContinentsRepository
    {
        private readonly ApplicationDbContext _context;
        public ContinentsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<SelectListItem> GetContinents()
        {
            var continents = _context.Continents
                .AsNoTracking()
                .OrderBy(n => n.Name)
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Name
                    }).ToList();

            var continent = new SelectListItem()
            {
                Value = null,
                Text = "--- Select Continent ---"
            };

            continents.Insert(0, continent);

            return new SelectList(continents, "Value", "Text");
        }
    }
}