using Domain.Entities;

namespace Domain.Dtos;

public class AddJobHistory
{
    public int EmployeeId { get; set; }
    public DateTime StartDate { get;set; }
    public DateTime EndDate { get;set; }
    public int JobId { get; set; }
    public int DepartmentId { get; set; }
}
