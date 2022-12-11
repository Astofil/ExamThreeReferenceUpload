using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

public class JobController
{
    private readonly JobService _jobService;
    public JobController(JobService jobService)
    {
        _jobService = jobService;
    }

    [HttpGet]
    public async Task<Response<List<GetJob>>> GetJob()
    {
        return await _jobService.GetJob();
    }

    [HttpPost]
    public async Task<Response<AddJob>> AddJob(AddJob job)
    {
        return await _jobService.AddJob(job);
    }

    [HttpPut]
    public async Task<Response<AddJob>> UpdateJob(AddJob job)
    {
        return await _jobService.UpdateJob(job);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteJob(int id)
    {
        return await _jobService.DeleteJob(id);
    }
}
