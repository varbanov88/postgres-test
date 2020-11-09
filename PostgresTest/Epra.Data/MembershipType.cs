using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epra.Data
{
    public class MembershipType
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
