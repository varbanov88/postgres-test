using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epra.Data
{
    public class Invoice
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        public Product Product { get; set; }


        [Column("membership_id")]
        public int? MemberShipId { get; set; }

        public Membership Membership { get; set; }

        [Column("due_date")]
        public DateTime DueDate { get; set; }

        [Column("status_id")]
        public int StatusId { get; set; }

        public InvoiceStatus Status { get; set; }

        [Column("number")]
        [MaxLength(20)]
        public string Number { get; set; }

        [Column("remarks")]
        public string Remarks { get; set; }

        [Column("created_date")]
        public DateTime? CreateDate { get; set; } 

        [Column("total")]
        public decimal Total { get; set; }

        [Column("email_sent_date")]
        public DateTime? EmailSentDate { get; set; }

        [Column("date_paid")]
        public DateTime? DatePaid { get; set; }

        [Column("is_credit")]
        public bool IsCredit { get; set; }

        [Column("debit_invoice_id")]
        public int? InvoiceId { get; set; }

        public Invoice DebitInvoice { get; set; }

        [Column("debit_invoice_nr")]
        public string DebitInvoiceNumber { get; set; }

        [Column("email_extra")]
        public string EmailExtra { get; set; }

        [Column("po_nr")]
        public string PoNr { get; set; }

        [Column("total_in_different_currency")]
        public string TotalInDifferentCurrency { get; set; }

        [Column("payment_via")]
        public string PaymentVia { get; set; }

        [Column("details")]
        public string Details { get; set; }

        [Column("vat")]
        public decimal? Vat { get; set; }

        [Column("discount")]
        public decimal? Discount { get; set; }

        public ICollection<Membership> Memberships { get; set; }
        public ICollection<Invoice> CreditInvoices { get; set; }
    }
}
