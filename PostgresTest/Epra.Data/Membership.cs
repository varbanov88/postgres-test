using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Epra.Data
{
    public class Membership
    {
        [Column("id")]
        public int Id { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}
