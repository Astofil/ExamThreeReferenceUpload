using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

public class LocationController
{
    private readonly LocationService _locationService;
    public LocationController(LocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet]
    public async Task<Response<List<GetLocation>>> GetLocation()
    {
        return await _locationService.GetLocation();
    }

    [HttpPost]
    public async Task<Response<AddLocation>> AddLocation(AddLocation location)
    {
        return await _locationService.AddLocation(location);
    }

    [HttpPut]
    public async Task<Response<AddLocation>> UpdateLocation(AddLocation location)
    {
        return await _locationService.UpdateLocation(location);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteLocation(int id)
    {
        return await _locationService.DeleteLocation(id);
    }
}
