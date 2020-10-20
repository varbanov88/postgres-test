using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epra.Data
{
    public class Product
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("vat")]
        public decimal? Vat { get; set; }

        [Column("product_code_id")]
        public int ProductCodeId { get; set; }

        public ProductCode ProductCode { get; set; }

        [Column("second_product_code")]
        [MaxLength(20)]
        public string SecondProductCode { get; set; }

        [Column("email_subject")]
        public string EmailSubject { get; set; }

        [Column("email_banner")]
        public string EmailBanner { get; set; }

        [Column("email_body")]
        public string EmailBody { get; set; }
        
        [Column("bottom_notes")]
        public string BottomNotes { get; set; }

        public ICollection<Invoice> Invoices { get; set; }

        public ICollection<Membership> Memberships { get; set; }
    }
}
