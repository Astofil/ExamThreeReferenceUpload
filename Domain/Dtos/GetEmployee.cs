using Domain.Entities;

namespace Domain.Dtos;

public class GetEmployee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public int Salary { get; set; }
    public int CommissionPct { get; set; }
    public int JobId { get; set; }
    public string JobTitle { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
}
