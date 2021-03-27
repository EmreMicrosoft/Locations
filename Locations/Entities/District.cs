using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locations.Entities
{
    public partial class District
    {
        public District()
        {
            Towns = new HashSet<Town>();
        }

        [Key]
        public int Id { get; set; }
        public int CityId { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Districts")]
        public virtual City City { get; set; }
        [InverseProperty(nameof(Town.District))]
        public virtual ICollection<Town> Towns { get; set; }
    }
}