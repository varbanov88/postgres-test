using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epra.Data
{
    public class Invoice
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("membership_id")]
        public int? MemberShipId { get; set; }

        public Membership Membership { get; set; }

        [Column("company_id")]
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        [Column("contact_id")]
        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        [Column("address_id")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [Column("invoice_status_id")]
        public int InvoiceStatusId { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }

        [Column("invoice_number")]
        public string InvoiceNumber { get; set; }

        [Column("remarks")]
        public string Remarks { get; set; }

        [Column("invoice_date")]
        [Required]
        public DateTime InvoiceDate { get; set; }

        [Column("total")]
        public decimal Total { get; set; }

        [Column("date_mail_sent")]
        public DateTime? DateMailSent { get; set; }

        [Column("bottom_notes")]

        public string BottomNotes { get; set; }

        [Column("date_paid")]
        public DateTime? DatePaid { get; set; }
        
        [Column("invoice_type")]
        public int InvoiceType { get; set; }

        [Column("booked")]
        public bool Booked { get; set; }

        [Column("email_extra")]
        [MaxLength(100)]
        public string EmailExtra { get; set; }

        [Column("product_code_id")]
        public int ProductCodeId { get; set; }
        public ProductCode ProductCode { get; set; }

        [Column("payment_via")]
        [MaxLength(50)]
        public string PaymentVia { get; set; }

        [Column("is_credited")]
        public bool IsCredited { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Column("discount_percent")]
        public decimal? DiscountPercent { get; set; }

        [Column("vat")]
        public decimal? Vat { get; set; }

        [Column("vat_comment")]
        public string VatComment { get; set; }
    }
}
