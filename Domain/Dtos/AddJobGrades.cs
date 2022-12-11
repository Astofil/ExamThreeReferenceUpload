using Domain.Entities;

namespace Domain.Dtos;

public class AddJobGrade
{
    public string GradeLevel { get; set; }
    public int LowestSalary { get; set; }
    public int HighestSalary { get; set; }
}
