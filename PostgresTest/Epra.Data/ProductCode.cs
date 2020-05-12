using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Epra.Data
{
    public class ProductCode
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Product> SecondProducts { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
