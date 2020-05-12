using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Epra.Data
{
    public class MembershipType
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Column("price")]
        public decimal Price { get; set; }

        public ICollection<Membership> Memberships { get;set; }
    }
}
