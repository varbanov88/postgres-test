using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Epra.Data
{
    public class Country
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column("code")]
        [MaxLength(10)]
        public string Code { get; set; }

        [Column("region")]
        [MaxLength(50)]
        public string Region { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
