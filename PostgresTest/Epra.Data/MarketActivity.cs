using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epra.Data
{
    public class MarketActivity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public  ICollection<Company> Companies { get; set; }
    }
}
