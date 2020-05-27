using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epra.Data
{
    public class Region
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get;set; }

        public ICollection<Country> Countries { get; set; }
    }
}
