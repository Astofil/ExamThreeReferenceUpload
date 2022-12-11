using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Npgsql;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class DepartmentService
{
    private readonly DataContext _context;
    public DepartmentService(DataContext context)
    {
        _context = context;
    }
    public async Task<Response<List<GetDepartment>>> GetDepartment()
    {
        var list = await _context.Departments.Select(t => new GetDepartment()
        {
            DepartmentId = t.DepartmentId,
            DepartmentName = t.DepartmentName,
            LocationId = t.LocationId,
            StreetAddress = t.StreetAddress,
            PostalCode = t.PostalCode,
            City = t.City,
        }).ToListAsync();
        await _context.SaveChangesAsync();
        return new Response<List<GetDepartment>>(list);
    }

    public async Task<Response<AddDepartment>> AddDepartment(AddDepartment department)
    {
        var newDepartment = new Department()
        {
            DepartmentId = department.DepartmentId,
            DepartmentName = department.DepartmentName,
            ManagerId = department.ManagerId,
            LocationId = department.LocationId,
        };
        _context.Departments.Add(newDepartment);
        await _context.SaveChangesAsync();
        return new Response<AddDepartment>(department);
    }
    public async Task<Response<AddDepartment>> UpdateDepartment(AddDepartment department)
    {
        var find = await _context.Departments.FindAsync(department.DepartmentId);
        find.DepartmentId = department.DepartmentId;
        find.DepartmentName = department.DepartmentName;
        find.ManagerId = department.ManagerId;
        find.LocationId = department.LocationId;
        await _context.SaveChangesAsync();
        return new Response<AddDepartment>(department);
    }
    public async Task<Response<string>> DeleteDepartment(int id)
    {
        var find = await _context.Departments.FindAsync(id);
        _context.Departments.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Department succesfully deleted");
    }
}
