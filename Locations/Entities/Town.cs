using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locations.Entities
{
    public partial class Town
    {
        [Key]
        public int Id { get; set; }
        public int DistrictId { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        [ForeignKey(nameof(DistrictId))]
        [InverseProperty("Towns")]
        public virtual District District { get; set; }
    }
}