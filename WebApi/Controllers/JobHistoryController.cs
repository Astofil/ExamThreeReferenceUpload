using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

public class JobHistoryController
{
    private readonly JobHistoryService _jobHistoryService;
    public JobHistoryController(JobHistoryService jobHistoryService)
    {
        _jobHistoryService = jobHistoryService;
    }

    [HttpGet]
    public async Task<Response<List<GetJobHistory>>> GetJobHistory()
    {
        return await _jobHistoryService.GetJobHistory();
    }

    [HttpPost]
    public async Task<Response<AddJobHistory>> AddJobHistory(AddJobHistory jobHistory)
    {
        return await _jobHistoryService.AddJobHistory(jobHistory);
    }

    [HttpPut]
    public async Task<Response<AddJobHistory>> UpdateJobHistory(AddJobHistory jobHistory)
    {
        return await _jobHistoryService.UpdateJobHistory(jobHistory);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteJobHistory(int id)
    {
        return await _jobHistoryService.DeleteJobHistory(id);
    }
}
