using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

public class CountryController
{
    private readonly CountryService _countryService;
    public CountryController(CountryService countryService)
    {
        _regionService = regionService;
    }

    [HttpGet]
    public async Task<Response<List<GetCountry>>> GetCountry()
    {
        return await _countryService.GetCountry();
    }

    [HttpPost]
    public async Task<Response<AddCountry>> AddCountry(AddCountry country)
    {
        return await _countryService.AddCountry(country);
    }

    [HttpPut]
    public async Task<Response<AddCountry>> UpdateCountry(AddCountry country)
    {
        return await _countryService.UpdateCountry(country);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteCountry(int id)
    {
        return await _countryService.DeleteCountry(id);
    }
}
