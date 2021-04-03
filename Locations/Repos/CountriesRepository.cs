using System.Collections.Generic;
using System.Linq;
using Locations.Data;
using Locations.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Locations.Repos
{
    public class CountriesRepository
    {
        private readonly ApplicationDbContext _context;
        public CountriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<SelectListItem> GetCountries()
        {
            var countries = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = " "
                }
            };
            return countries;
        }


        public IEnumerable<SelectListItem> GetCountries(string continentId)
        {
            if (string.IsNullOrWhiteSpace(continentId))
                return null;

            var countries = _context.Countries
                .AsNoTracking()
                .Where(n => n.ContinentId.ToString() == continentId)
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Name
                    }).ToList();

            return new SelectList(countries,
                "Value", "Text");
        }

        public bool AddCountry(Country country)
        {
            if (country == null)
                return false;

            _context.Countries.Add(country);
            _context.SaveChanges();

            return true;
        }
    }
}