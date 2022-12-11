using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

public class EmployeeController
{
    private readonly EmployeeService _employeeService;
    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<Response<List<GetEmployee>>> GetEmployee()
    {
        return await _employeeService.GetEmployee();
    }

    [HttpPost]
    public async Task<Response<AddEmployee>> AddEmployee(AddEmployee employee)
    {
        return await _employeeService.AddEmployee(employee);
    }

    [HttpPut]
    public async Task<Response<AddEmployee>> UpdateEmployee(AddEmployee employee)
    {
        return await _employeeService.UpdateEmployee(employee);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteEmployee(int id)
    {
        return await _employeeService.DeleteEmployee(id);
    }
}
