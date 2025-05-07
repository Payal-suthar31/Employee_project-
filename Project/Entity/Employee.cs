using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emp_project.Entity
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string? FullName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(50)]
        public string? Department { get; set; }

        [StringLength(50)]
        public string? Position { get; set; }

        [Required]
        public DateTime Date_Of_Joining { get; set; }

        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime Created { get; set; }

        [Required]
        [ForeignKey("CreatedByUser")]
        public int CreatedBy { get; set; }

        public User? CreatedByUser { get; set; }  // Who created the employee

        public ICollection<Report>? Reports { get; set; }
    }
}
