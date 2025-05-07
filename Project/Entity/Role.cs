using System.ComponentModel.DataAnnotations;

public class Role
{
    [Key]
    public int RoleId { get; set; }

    
    public required string RoleName { get; set; }
}
