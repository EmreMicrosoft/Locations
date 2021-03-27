using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locations.Entities
{
    public partial class State
    {
        public State()
        {
            Cities = new HashSet<City>();
        }

        [Key]
        public short Id { get; set; }
        public byte CountryId { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty("States")]
        public virtual Country Country { get; set; }
        [InverseProperty(nameof(City.State))]
        public virtual ICollection<City> Cities { get; set; }
    }
}