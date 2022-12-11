using Domain.Entities;

namespace Domain.Dtos;

public class GetLocation
{
    public int LocationId { get; set; }
    public string StreetAddress { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public int CountryId { get; set; }
    public string CountryName { get; set; }
}