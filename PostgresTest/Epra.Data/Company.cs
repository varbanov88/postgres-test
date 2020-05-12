using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epra.Data
{
    public class Company
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("search_name")]
        public string SearchName { get; set; }

        [Column("company_type_id")]
        public int CompanyTypeId { get; set; }
        public CompanyType CompanyType { get; set; }

        [Column("member_index")]
        public bool MemberIndex { get; set; }

        [Column("market_activity_id")]
        public int MarketActivityId { get; set; }

        public MarketActivity MarketActivity { get; set; }

        [Column("market_second_specialty")]
        public string MarketSecondSpecialty { get; set; }

        [Column("website")]

        public string Website { get; set; }

        [Column("info")]

        public string Info { get; set; }

        [Column("unique_stock_code")]
        public string UniqueStockCode { get; set; }

        [Column("address_id")]
        public int? AddressId { get; set; }

        public Address Address { get; set; }

        [Column("membership_id")]
        public int? MembershipId { get; set; } 

        public Membership Membership { get; set; }

        [Column("is_main_member")]
        public bool IsMainMember { get; set; }
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
