using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epra.Data
{
    public class Address
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [Required]
        public string Name { get; set; }
        [Column("street")]
        [Required]
        public string Street { get; set; }

        [Column("city")]
        [Required]
        public string City { get; set; }

        [Column("country_id")]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        [Column("zip")]
        [MaxLength(20)]
        public string Zip { get; set; }

        [Column("vat_number")]
        [MaxLength(50)]
        public string VatNumber { get; set; }
        [Column("fax")]
        [MaxLength(50)]
        public string Fax { get; set; }
        [Column("phone")]
        [MaxLength(50)]
        public string Phone { get; set; }

        [Column("is_main")]
        public bool IsMain { get; set; }

        [Column("is_nav")]
        public bool IsNav { get; set; }
        [Column("is_website")]
        public bool IsWebsite { get; set; }
        
        [Column("email")]
        public string Email { get; set; }

        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
        public ICollection<Company> Companies { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
