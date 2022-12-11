namespace Domain.Entities;

public class Country
{
    public int CountryId { get; set; }
    public string CountryName { get; set; }
    public int RegionId { get; set; }
    public Region Region { get; set; }

    public virtual List<Location> Locations { get; set; }
}
