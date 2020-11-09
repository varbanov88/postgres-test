using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epra.Data
{
    public class Contact
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("middle_name")]
        public string MiddleName { get; set; }

        [Column("last_name")]
        [Required]
        public string LastName { get; set; }

        [Column("prefix")]
        public string Prefix { get; set; }

        [Column("suffix")]
        public string Suffix { get; set; }

        [Column("informal_name")]
        public string InformalName { get; set; }

        [Column("title_internal_id")]
        public int TitleInternalId { get; set; }

        public TitleInternal TitleInternal { get; set; }

        [Column("title_external")]
        public string TitleExternal { get; set; }

        [Column("phone_direct")]
        public string PhoneDirect { get; set; }

        [Column("phone_mobile")]
        public string  PhoneMobile{ get; set; }

        [Column("fax")]
        public string Fax { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        [Column("location_of_contact")]
        public string Location { get; set; }

        [Column("company_id")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Column("is_main")]
        public bool IsMain{get;set;}
        [Column("online")]
        public bool Online { get; set; }

        [Column("address_id")]
        public int? AddressId { get; set; }

        public Address Address { get; set; }

        [Column("assistant_id")]

        public int? AssistantId { get; set; }
        public Contact Assistant { get; set; }

        public ICollection<Contact> Bosses { get; set; }
    }
}
