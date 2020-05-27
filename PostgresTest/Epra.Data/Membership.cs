using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Epra.Data
{
    public class Membership
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("is_bad_debtor")]
        public bool IsBadDebtor { get; set; }

        
        [Column("discount")]
        public decimal? Discount { get; set; }

        [Column("total")]
        public decimal Total { get; set; }

        [Column("comment")]
        public string Comment { get; set; }

        [Column("start_date")]
        public DateTime? StartDate { get; set; }

        [Column("end_date")]
        public DateTime? EndDate { get; set; }

        [Column("renewable_date")]
        public DateTime? RenewableDate { get; set; }

        [Column("product_id")]

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public ICollection<Company> Companies { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
