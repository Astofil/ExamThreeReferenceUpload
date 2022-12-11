using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Npgsql;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class RegionService
{
    private readonly DataContext _context;
    public RegionService(DataContext context)
    {
        _context = context;
    }
    public async Task<Response<List<GetRegion>>> GetRegion()
    {
        var list = await _context.Regions.Select(t => new GetRegion()
        {
            RegionId = t.RegionId,
            RegionName = t.RegionName
        }).ToListAsync();
        await _context.SaveChangesAsync();
        return new Response<List<GetRegion>>(list);
    }

    public async Task<Response<AddRegion>> AddRegion(AddRegion region)
    {
        var newRegion = new Region()
        {
            RegionId = region.RegionId,
            RegionName = region.RegionName
        };
        _context.Regions.Add(newRegion);
        await _context.SaveChangesAsync();
        return new Response<AddRegion>(region);
    }
    public async Task<Response<AddRegion>> UpdateRegion(AddRegion region)
    {
        var find = await _context.Regions.FindAsync(region.RegionId);
        find.RegionId = region.RegionId;
        find.RegionName = region.RegionName;
        await _context.SaveChangesAsync();
        return new Response<AddRegion>(region);
    }
    public async Task<Response<string>> DeleteRegion(int id)
    {
        var find = await _context.Regions.FindAsync(id);
        _context.Regions.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Region succesfully deleted");
    }
}
