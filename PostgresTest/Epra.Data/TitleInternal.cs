﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Epra.Data
{
    public class TitleInternal
    {
        [Column("id")]
        public int Id{ get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        public  ICollection<Contact> Contacts { get; set; }
    }
}
