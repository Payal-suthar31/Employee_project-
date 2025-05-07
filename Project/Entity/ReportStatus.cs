using System.ComponentModel.DataAnnotations;

namespace Emp_project.Entity
{
    public class ReportStatus
    {
        [Key]
        public int StatusId { get; set; }

     
        public required string StatusName { get; set; }

        public ICollection<Report>? Reports { get; set; } 
    }
}
