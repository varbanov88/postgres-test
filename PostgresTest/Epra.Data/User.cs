using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epra.Data
{
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        [Required]
        public string Username { get; set; }

        [Column("password")]
        [Required]
        public string Password { get; set; }

        public ICollection<UserRoles> Roles { get; set; } = new List<UserRoles>();
    }
}
