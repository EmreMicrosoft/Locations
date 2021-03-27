using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locations.Entities
{
    public partial class City
    {
        public City()
        {
            Districts = new HashSet<District>();
        }

        [Key]
        public int Id { get; set; }
        public byte CountryId { get; set; }
        public short? StateId { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty("Cities")]
        public virtual Country Country { get; set; }
        [ForeignKey(nameof(StateId))]
        [InverseProperty("Cities")]
        public virtual State State { get; set; }
        [InverseProperty(nameof(District.City))]
        public virtual ICollection<District> Districts { get; set; }
    }
}