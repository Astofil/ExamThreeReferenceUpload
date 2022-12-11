using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

public class DepartmentController
{
    private readonly DepartmentService _departmentService;
    public DepartmentController(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<Response<List<GetDepartment>>> GetDepartment()
    {
        return await _departmentService.GetDepartment();
    }

    [HttpPost]
    public async Task<Response<AddDepartment>> AddDepartment(AddDepartment department)
    {
        return await _departmentService.AddDepartment(department);
    }

    [HttpPut]
    public async Task<Response<AddDepartment>> UpdateDepartment(AddDepartment department)
    {
        return await _departmentService.UpdateDepartment(department);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteDepartment(int id)
    {
        return await _departmentService.DeleteDepartment(id);
    }
}
