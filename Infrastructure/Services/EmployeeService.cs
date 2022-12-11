using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Npgsql;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmployeeService
{
    private readonly DataContext _context;
    public EmployeeService(DataContext context)
    {
        _context = context;
    }
    public async Task<Response<List<GetEmployee>>> GetEmployee()
    {
        var list = await _context.Employees.Select(t => new GetEmployee()
        {
            EmployeeId = t.EmployeeId,
            FirstName = t.FirstName,
            LastName = t.LastName,
            Email = t.Email,
            PhoneNumber = t.PhoneNumber,
            HireDate = t.HireDate,
            Salary = t.Salary,
            CommissionPct = t.CommissionPct,
            JobId = t.JobId,
            JobTitle = t.JobTitle,
            MinSalary = t.MinSalary,
            MaxSalary = t.MaxSalary,
            DepartmentId = t.DepartmentId,
            DepartmentName = t.DepartmentName,
        }).ToListAsync();
        await _context.SaveChangesAsync();
        return new Response<List<GetEmployee>>(list);
    }

    public async Task<Response<AddEmployee>> AddEmployee(AddEmployee employee)
    {
        var newEmployee = new Employee()
        {
            EmployeeId = employee.EmployeeId,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber,
            HireDate = employee.HireDate,
            Salary = employee.Salary,
            CommissionPct = employee.CommissionPct,
            JobId = employee.JobId,
            JobTitle = employee.JobTitle,
            MinSalary = employee.MinSalary,
            MaxSalary = employee.MaxSalary,
            DepartmentId = employee.DepartmentId,
            DepartmentName = employee.DepartmentName,
        };
        _context.Employees.Add(newEmployee);
        await _context.SaveChangesAsync();
        return new Response<AddEmployee>(employee);
    }
    public async Task<Response<AddEmployee>> UpdateEmployee(AddEmployee employee)
    {
        var find = await _context.Employees.FindAsync(department.EmployeeId);
        find.EmployeeId = employee.EmployeeId;
        find.FirstName = employee.FirstName;
        find.LastName = employee.LastName;
        find.Email = employee.Email;
        find.PhoneNumber = employee.PhoneNumber;
        find.HireDate = employee.HireDate;
        find.Salary = employee.Salary;
        find.CommissionPct = employee.CommissionPct;
        find.JobId = employee.JobId;
        find.JobTitle = employee.JobTitle;
        find.MinSalary = employee.MinSalary;
        find.MaxSalary = employee.MaxSalary;
        find.DepartmentId = employee.DepartmentId;
        find.DepartmentName = employee.DepartmentName;
        await _context.SaveChangesAsync();
        return new Response<AddEmployee>(employee);
    }
    public async Task<Response<string>> DeleteEmployee(int id)
    {
        var find = await _context.Employees.FindAsync(id);
        _context.Employees.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Employee succesfully deleted");
    }
}
