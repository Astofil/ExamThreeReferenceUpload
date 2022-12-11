namespace Domain.Entities;

public class Location
{
    public int LocationId { get; set; }
    public string StreetAddress { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }

    public int CountryId { get; set; }
    public Country Country { get; set; }

    public virtual List<Department> Departments { get; set; }
}

