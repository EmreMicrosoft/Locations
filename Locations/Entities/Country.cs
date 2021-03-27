﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locations.Entities
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
            States = new HashSet<State>();
        }

        [Key]
        public byte Id { get; set; }
        public byte ContinentId { get; set; }
        [Required]
        [StringLength(24)]
        public string Name { get; set; }

        [ForeignKey(nameof(ContinentId))]
        [InverseProperty("Countries")]
        public virtual Continent Continent { get; set; }
        [InverseProperty(nameof(City.Country))]
        public virtual ICollection<City> Cities { get; set; }
        [InverseProperty(nameof(State.Country))]
        public virtual ICollection<State> States { get; set; }
    }
}