using Emp_project.Entity;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<ReportStatus> ReportStatuses { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Role
        modelBuilder.Entity<Role>(e =>
        {
            e.ToTable("roles");
            e.HasKey(r => r.RoleId);

            e.Property(r => r.RoleId)
             .HasColumnName("role_id")
             .ValueGeneratedOnAdd();

            e.Property(r => r.RoleName)
             .HasColumnName("role_name")
             .IsRequired();
        });

        modelBuilder.Entity<Role>().HasData(
    new Role { RoleId = 1, RoleName = "Admin" },
    new Role { RoleId = 2, RoleName = "Employee" }
);

        modelBuilder.Entity<User>(e =>
        {
            e.ToTable("users");
            e.HasKey(u => u.UserId);

            e.Property(u => u.UserId)
             .HasColumnName("user_id")
             .ValueGeneratedOnAdd()
             .IsRequired();

            e.Property(u => u.UserName)
             .HasColumnName("username")
             .IsRequired();

            e.Property(u => u.Email)
             .HasColumnName("email")
             .IsRequired();

            e.Property(u => u.Password)
             .HasColumnName("password")
             .IsRequired();

            e.Property(u => u.RoleId)
             .HasColumnName("role_id")
             .IsRequired();

            e.Property(u => u.IsActive)
             .HasColumnName("is_active")
             .IsRequired();

            e.Property(u => u.Created)
             .HasColumnName("created")
             .IsRequired();
        });

        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1,
                UserName = "admin",
                Email = "admin@example.com",
                Password = "admin123",
                RoleId = 1,
                IsActive = true,
                Created = new DateTime(2023, 1, 1)
            },
            new User
            {
                UserId = 2,
                UserName = "employee1",
                Email = "employee1@example.com",
                Password = "emp123",
                RoleId = 2,
                IsActive = true,
                Created = new DateTime(2023, 3, 15)
            }
        );

        // Employee
        modelBuilder.Entity<Employee>(e =>
        {
            e.ToTable("employees");
            e.HasKey(emp => emp.EmployeeId);

            e.Property(emp => emp.EmployeeId)
             .HasColumnName("employee_id")
             .ValueGeneratedOnAdd();

            e.Property(emp => emp.FullName)
             .HasColumnName("fullname")
             .IsRequired();

            e.Property(emp => emp.Email)
             .HasColumnName("email")
             .IsRequired();

            e.Property(emp => emp.Department)
             .HasColumnName("department");

            e.Property(emp => emp.Position)
             .HasColumnName("position");

            e.Property(emp => emp.Date_Of_Joining)
             .HasColumnName("dateofjoining")
             .IsRequired();

            e.Property(emp => emp.IsActive)
             .HasColumnName("is_active")
             .IsRequired();

            e.Property(emp => emp.Created)
             .HasColumnName("created")
             .IsRequired();

            e.Property(emp => emp.CreatedBy)
             .HasColumnName("created_by")
             .IsRequired();
        });

        //modelBuilder.Entity<Employee>().HasData(
        //    new Employee
        //    {
        //        EmployeeId = 2,
        //        FullName = "Priyanshika",
        //        Email = "priyanshika@example.com",
        //        Department = "IT",
        //        Position = "Developer",
        //        Date_Of_Joining = new DateTime(2023, 2, 15),
        //        IsActive = true,
        //        Created = new DateTime(2023, 2, 10),
        //        CreatedBy = 1
        //    }
        //);
    modelBuilder.Entity<Employee>().HasData(
        new 
        {
             EmployeeId = 2,
             FullName = "Priyanshika",
             Email = "priyanshika@example.com",
             Department = "IT",
             Position = "Developer",
             Date_Of_Joining = new DateTime(2023, 2, 15),
            IsActive = true,
            Created = new DateTime(2023, 2, 10),
            CreatedBy = 1
        }
       );


        // Report Status
        modelBuilder.Entity<ReportStatus>(e =>
        {
            e.ToTable("report_statuses");
            e.HasKey(rs => rs.StatusId);

            e.Property(rs => rs.StatusId)
             .HasColumnName("status_id")
             .ValueGeneratedOnAdd()
             .IsRequired();

            e.Property(rs => rs.StatusName)
             .HasColumnName("status_name")
             .IsRequired();

            e.HasMany<Report>()
             .WithOne()
             .HasForeignKey(r => r.StatusId)
             .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<ReportStatus>().HasData(
            new ReportStatus { StatusId = 1, StatusName = "Cancelled" },
            new ReportStatus { StatusId = 2, StatusName = "Pending" },
            new ReportStatus { StatusId = 3, StatusName = "Approved" }
        );

        // Report
        modelBuilder.Entity<Report>(e =>
        {
            e.ToTable("reports");
            e.HasKey(r => r.ReportId);

            e.Property(r => r.ReportId)
             .HasColumnName("report_id")
             .ValueGeneratedOnAdd();

            e.Property(r => r.Title)
             .HasColumnName("title")
             .IsRequired();

            e.Property(r => r.Content)
             .HasColumnName("content")
             .IsRequired();

            e.Property(r => r.CreatedAt)
             .HasColumnName("created_at")
             .IsRequired();

            e.Property(r => r.StatusId)
             .HasColumnName("status_id")
             .IsRequired();

            e.Property(r => r.ReviewedAt)
             .HasColumnName("reviewed_at")
             .IsRequired();

            e.Property(r => r.ReviewerName)
             .HasColumnName("reviewer_name")
             .IsRequired();

            e.Property(r => r.Remarks)
             .HasColumnName("remarks")
             .IsRequired();

            e.Property(r => r.EmployeeId)
             .HasColumnName("employee_id")
             .IsRequired();

            e.HasOne(r => r.Status)
             .WithMany()
             .HasForeignKey(r => r.StatusId)
             .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Report>().HasData(
            new Report
            {
                ReportId = 1,
                Title = "Project Review",
                Content = "This report summarizes the project status and blockers.",
                CreatedAt = new DateTime(2023, 5, 1),
                StatusId = 1,
                ReviewedAt = new DateTime(2023, 5, 2),
                ReviewerName = "Priyanshika",
                Remarks = "The project is on track. No major blockers were encountered.",
                EmployeeId = 2
            }
        );
    }
}
