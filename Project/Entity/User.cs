using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emp_project.Entity
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string? UserName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(100)]
        public string? Password { get; set; }

        // Foreign Key to Role
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        // Navigation Property to Role
        public Role? Role { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public DateTime Created { get; set; }
    }
}
