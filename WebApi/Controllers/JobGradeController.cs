using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

public class JobGradeController
{
    private readonly JobGradeService _jobGradeService;
    public JobGradeController(JobGradeService jobGradeService)
    {
        _jobGradeService = jobGradeService;
    }

    [HttpGet]
    public async Task<Response<List<GetJobGrade>>> GetJobGrade()
    {
        return await _jobGradeService.GetJobGrade();
    }

    [HttpPost]
    public async Task<Response<AddJobGrade>> AddJobGrade(AddJobGrade jobGrade)
    {
        return await _jobGradeService.AddJobGrade(jobGrade);
    }
    
}
