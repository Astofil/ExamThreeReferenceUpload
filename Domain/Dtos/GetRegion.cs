using Domain.Entities;

namespace Domain.Dtos;

public class GetRegion
{
    public int RegionId { get; set; }
    public string RegionName { get; set; }
}
