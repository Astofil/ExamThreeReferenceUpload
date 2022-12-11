using Domain.Entities;

namespace Domain.Dtos;

public class GetJobHistory
{
    public int EmployeeId { get; set; }
    public DateTime StartDate { get;set; }
    public DateTime EndDate { get;set; }
    public int JobId { get; set; }
    public string JobTitle { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
}
