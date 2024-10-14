using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tazkarty.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        public Role Role { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }

    public enum Role
    {
        Admin,
        User
    }
}
