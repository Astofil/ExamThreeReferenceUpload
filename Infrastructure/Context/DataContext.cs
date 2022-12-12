using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<EmployeeDepartment>().HasKey(sc => new { sc.EmployeeId, sc.DepartmentId });

        modelBuilder.Entity<Country>()
        .HasOne<Region>( r => r.Regions)
        .WithMany(c => c.Countries)
        .HasForeignKey(r => r.RegionId);

        modelBuilder.Entity<Location>()
        .HasOne<Country>(c => c.Countries)
        .WithMany(l => l.Locations)
        .HasForeignKey(c => c.CountryId);

        modelBuilder.Entity<Department>()
        .HasOne<Location>(l => l.Locations)
        .WithMany(d => d.Departments)
        .HasForeignKey(l => l.LocationId);

        modelBuilder.Entity<Department>()
        .HasOne<Employee>(y => y.Employees)
        .WithMany(d => d.Departments)
        .HasForeignKey(y => y.ManagerId); //////////////////////////////////////////////

        modelBuilder.Entity<Employee>()
        .HasOne<Department>(d => d.Departments)
        .WithMany(e => e.Employees)
        .HasForeignKey(d => d.DepartmentId);

        modelBuilder.Entity<JobHistory>()
        .HasOne<Department>(d => d.Departments)
        .WithMany(j => j.JobHistories)
        .HasForeignKey(d => d.DepartmentId);

        modelBuilder.Entity<JobHistory>()
        .HasOne<Country>(e => e.Employees)
        .WithMany(j => j.JobHistories)
        .HasForeignKey(e => e.EmployeeId);

        modelBuilder.Entity<Employee>()
        .HasOne<Country>(j => j.Jobs)
        .WithMany(e => e.Employees)
        .HasForeignKey(e => e.EmployeeId);

        modelBuilder.Entity<JobHistory>()
        .HasOne<Country>(j => j.Jobs)
        .WithMany(jH => jH.JobHistories)
        .HasForeignKey(j => j.JobId);

        // modelBuilder.Entity<Location>()
        // .HasOne<Country>(c => c.Countries)
        // .WithMany(l => l.Locations)
        // .HasForeignKey(c => c.CountryId);
    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees{ get; set; }
    public DbSet<Job> Jobs{ get; set; }
    public DbSet<JobGrade> jobGrades{ get; set; }
    public DbSet<JobHistory> JobHistories{ get; set; }
    public DbSet<Location> Locations{ get; set; }
    public DbSet<Region> Regions{ get; set; }
}

