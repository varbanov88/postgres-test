using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Epra.Data
{
    public class UserRoles
    {
        [Column("user_id")]
        public int UserId { get; set; }

        public User User { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
