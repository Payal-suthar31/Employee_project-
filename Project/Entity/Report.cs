using Emp_project.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Report
{
    public int ReportId { get; set; }

    public required string Title { get; set; }

    public required string Content { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("Status")]
    public int StatusId { get; set; }
    public ReportStatus? Status { get; set; } // Make this nullable (remove 'required')

    [Required]
    public DateTime ReviewedAt { get; set; }

    public required string ReviewerName { get; set; }

    public required string Remarks { get; set; }

    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }  // Make this nullable (remove 'required')
}
 