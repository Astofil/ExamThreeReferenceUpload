using Domain.Entities;

namespace Domain.Dtos;

public class AddDepartment
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public int ManagerId { get; set; }
    public int LocationId { get; set; }
}
