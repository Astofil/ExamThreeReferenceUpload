using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {

    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<EmployeeDepartment>().HasKey(sc => new { sc.EmployeeId, sc.DepartmentId });

    //     modelBuilder.Entity<EmployeeDepartment>()
    //     .HasOne<Employee>( sc => sc.Employee)
    //     .WithMany(s => s.EmployeeDepartments)
    //     .HasForeignKey(sc => sc.EmployeeId);

    //     modelBuilder.Entity<EmployeeDepartment>()
    //     .HasOne<Department>(sc => sc.Department)
    //     .WithMany(s => s.EmployeeDepartments)
    //     .HasForeignKey(sc => sc.DepartmentId);
    // }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees{ get; set; }
    public DbSet<Job> Jobs{ get; set; }
    public DbSet<JobGrade> jobGrades{ get; set; }
    public DbSet<JobHistory> JobHistories{ get; set; }
    public DbSet<Location> Locations{ get; set; }
    public DbSet<Region> Regions{ get; set; }
}

