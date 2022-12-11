using Domain.Entities;

namespace Domain.Dtos;

public class AddLocation
{
    public int LocationId { get; set; }
    public string StreetAddress { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public int CountryId { get; set; }
}