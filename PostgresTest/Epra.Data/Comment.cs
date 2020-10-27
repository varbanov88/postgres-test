using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Epra.Data
{
    public class Comment
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("text")]
        [Required]
        public string Text { get; set; }

        [Column("membership_id")]
        public int MembershipId { get; set; }

        public Membership Membership { get; set; }

        [Column("author_id")]
        public int AuthorId { get; set; }

        public User Author { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }
    }
}
