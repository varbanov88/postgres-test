using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epra.Data
{
    public class Address
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("city")]
        [Required]
        public string City { get; set; }

        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
