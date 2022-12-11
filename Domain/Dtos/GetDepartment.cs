using Domain.Entities;

namespace Domain.Dtos;

public class GetDepartment
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public int LocationId { get; set; }
    public string StreetAddress { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
}
