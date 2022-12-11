using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

public class RegionController
{
    private readonly RegionService _regionService;
    public RegionController(RegionService regionService)
    {
        _regionService = regionService;
    }

    [HttpGet]
    public async Task<Response<List<GetRegion>>> GetRegion()
    {
        return await _regionService.GetRegion();
    }

    [HttpPost]
    public async Task<Response<AddRegion>> AddRegion(AddRegion region)
    {
        return await _regionService.AddRegion(region);
    }

    [HttpPut]
    public async Task<Response<AddRegion>> UpdateRegion(AddRegion region)
    {
        return await _regionService.UpdateRegion(region);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteRegion(int id)
    {
        return await _regionService.DeleteRegion(id);
    }
}
