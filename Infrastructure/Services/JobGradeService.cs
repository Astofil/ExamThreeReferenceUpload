using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Npgsql;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class JobGradeService
{
    private readonly DataContext _context;
    public JobGradeService(DataContext context)
    {
        _context = context;
    }
    public async Task<Response<List<GetJobGrade>>> GetJobGrade()
    {
        var list = await _context.JobGrades.Select(t => new GetJobGrade()
        {
            GradeLevel = t.GradeLevel,
            LowestSalary = t.LowestSalary,
            HighestSalary = t.HighestSalary,
        }).ToListAsync();
        await _context.SaveChangesAsync();
        return new Response<List<GetJobGrade>>(list);
    }

    public async Task<Response<AddJobGrade>> AddJobGrade(AddJobGrade jobGrade)
    {
        var newJobGrade = new JobGrade()
        {
            GradeLevel = jobGrade.GradeLevel,
            LowestSalary = jobGrade.LowestSalary,
            HighestSalary = jobGrade.HighestSalary,
        };
        _context.JobGrades.Add(newJobGrade);
        await _context.SaveChangesAsync();
        return new Response<AddJobGrade>(jobGrade);
    }
}
