using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locations.Entities
{
    public partial class Continent
    {
        public Continent()
        {
            Countries = new HashSet<Country>();
        }

        [Key]
        public byte Id { get; set; }
        [Required]
        [StringLength(16)]
        public string Name { get; set; }

        [InverseProperty(nameof(Country.Continent))]
        public virtual ICollection<Country> Countries { get; set; }
    }
}