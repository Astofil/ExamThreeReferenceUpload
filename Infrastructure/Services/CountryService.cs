using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Npgsql;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CountryService
{
    private readonly DataContext _context;
    public CountryService(DataContext context)
    {
        _context = context;
    }
    public async Task<Response<List<GetCountry>>> GetCountry()
    {
        var list = await _context.Countries.Select(t => new GetCountry()
        {
            CountryId = t.CountryId,
            CountryName = t.CountryName,
            RegionId = t.RegionId,
            RegionName = t.RegionName
        }).ToListAsync();
        await _context.SaveChangesAsync();
        return new Response<List<GetCountry>>(list);
    }

    public async Task<Response<AddCountry>> AddCountry(AddCountry country)
    {
        var newCountry = new Country()
        {
            CountryId = country.CountryId,
            CountryName = country.CountryName,
            RegionId = country.RegionId
        };
        _context.Countries.Add(newCountry);
        await _context.SaveChangesAsync();
        return new Response<AddCountry>(country);
    }
    public async Task<Response<AddCountry>> UpdateCountry(AddCountry country)
    {
        var find = await _context.Countries.FindAsync(country.CountryId);
        find.CountryId = country.CountryId;
        find.CountryName = country.CountryName;
        find.RegionId = country.RegionId;
        await _context.SaveChangesAsync();
        return new Response<AddCountry>(country);
    }
    public async Task<Response<string>> DeleteCountry(int id)
    {
        var find = await _context.Countries.FindAsync(id);
        _context.Countries.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Country succesfully deleted");
    }
}
