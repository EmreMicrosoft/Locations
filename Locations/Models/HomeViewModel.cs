using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Locations.Models
{
    public class HomeViewModel
    {
        public byte SelectedContinentId { get; set; }
        public IEnumerable<SelectListItem> Continents { get; set; }

        public byte SelectedCountryId { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }

        public short? SelectedStateId { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
    }
}