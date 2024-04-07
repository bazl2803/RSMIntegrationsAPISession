﻿namespace Application.Interfaces
{
    using Application.DTOs;

    public interface IDepartmentService
    {
        Task<GetDepartmentDto?> GetDepartmentById(int id);
        Task<IEnumerable<GetDepartmentDto>> GetAll();
        Task<int> CreateDepartment(CreateDepartmentDto departmentDto);
        Task<int> UpdateDepartment(UpdateDepartmentDto departmentDto);
        Task<int> DeleteDepartment(int id);
    }
}
