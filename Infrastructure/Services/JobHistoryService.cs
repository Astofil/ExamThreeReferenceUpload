using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Npgsql;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class JobHistoryService
{
    private readonly DataContext _context;
    public JobHistoryService(DataContext context)
    {
        _context = context;
    }
    public async Task<Response<List<GetJobHistory>>> GetJobHistory()
    {
        var list = await _context.JobHistories.Select(t => new GetJobHistory()
        {
            EmployeeId = t.EmployeeId,
            StartDate = t.StartDate,
            EndDate = t.EndDate,
            JobId = t.JobId,
            JobTitle = t.JobTitle,
            MinSalary = t.MinSalary,
            MaxSalary = t.MaxSalary,
            DepartmentId = t.DepartmentId,
            DepartmentName = t.DepartmentName,
        }).ToListAsync();
        await _context.SaveChangesAsync();
        return new Response<List<GetJobHistory>>(list);
    }

    public async Task<Response<AddJobHistory>> AddJobHistory(AddJobHistory jobHistory)
    {
        var newJobHistory = new JobHistory()
        {
            EmployeeId = jobHistory.EmployeeId,
            StartDate = jobHistory.StartDate,
            EndDate = jobHistory.EndDate,
            JobId = jobHistory.JobId,
            DepartmentId = jobHistory.DepartmentId,
        };
        _context.JobHistories.Add(newJobHistory);
        await _context.SaveChangesAsync();
        return new Response<AddJobHistory>(jobHistory);
    }
    public async Task<Response<AddJobHistory>> UpdateJobHistory(AddJobHistory jobHistory)
    {
        var find = await _context.JobHistories.FindAsync(jobHistory.EmployeeId);
        find.EmployeeId = jobHistory.EmployeeId;
        find.StartDate = jobHistory.StartDate;
        find.EndDate = jobHistory.EndDate;
        find.JobId = jobHistory.JobId;
        find.DepartmentId = jobHistory.DepartmentId;
        await _context.SaveChangesAsync();
        return new Response<AddJobHistory>(jobHistory);
    }
    public async Task<Response<string>> DeleteJobHistory(int id)
    {
        var find = await _context.JobHistories.FindAsync(id);
        _context.JobHistories.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("JobHistory succesfully deleted");
    }
}
JobHistory