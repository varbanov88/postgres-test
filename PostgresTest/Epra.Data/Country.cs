using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epra.Data
{
    public class Country
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column("code")]
        [MaxLength(10)]
        public string Code { get; set; }

        [Column("region_id")]
        public int RegionId { get; set; }

        public Region Region { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
