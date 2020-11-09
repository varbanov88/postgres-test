using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epra.Data
{
    public class InvoiceStatus
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}
