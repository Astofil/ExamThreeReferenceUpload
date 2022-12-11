using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Npgsql;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class JobService
{
    private readonly DataContext _context;
    public JobService(DataContext context)
    {
        _context = context;
    }
    public async Task<Response<List<GetJob>>> GetJob()
    {
        var list = await _context.Jobs.Select(t => new GetJob()
        {
            JobId = t.JobId,
            JobTitle = t.JobTitle,
            MinSalary = t.MinSalary,
            MaxSalary = t.MaxSalary,
        }).ToListAsync();
        await _context.SaveChangesAsync();
        return new Response<List<GetJob>>(list);
    }

    public async Task<Response<AddJob>> AddJob(AddJob job)
    {
        var newJob = new Job()
        {
            JobId = job.JobId,
            JobTitle = job.JobTitle,
            MinSalary = job.MinSalary,
            MaxSalary = job.MaxSalary,
        };
        _context.Jobs.Add(newJob);
        await _context.SaveChangesAsync();
        return new Response<AddJob>(job);
    }
    public async Task<Response<AddJob>> UpdateJob(AddJob job)
    {
        var find = await _context.Jobs.FindAsync(job.JobId);
        find.JobId = job.JobId;
        find.JobTitle = job.JobTitle;
        find.MinSalary = job.MinSalary;
        find.MaxSalary = job.MaxSalary;
        await _context.SaveChangesAsync();
        return new Response<AddJob>(job);
    }
    public async Task<Response<string>> DeleteJob(int id)
    {
        var find = await _context.Jobs.FindAsync(id);
        _context.Jobs.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Job succesfully deleted");
    }
}
