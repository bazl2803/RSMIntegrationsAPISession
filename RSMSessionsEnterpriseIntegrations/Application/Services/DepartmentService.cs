namespace Application.Services
{
    using Application.DTOs.Departament;
    using Application.Exceptions;
    using Application.Interfaces;
    using Domain.Interfaces;
    using Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository repository)
        {
            _departmentRepository = repository;
        }

        public async Task<int> CreateDepartment(CreateDepartmentDto departmentDto)
        {
            if (departmentDto is null 
                || string.IsNullOrWhiteSpace(departmentDto.Name) 
                || string.IsNullOrWhiteSpace(departmentDto.GroupName))
            {
                throw new BadRequestException("Department info is not valid.");
            }

            Department department = new()
            {
                GroupName = departmentDto.GroupName,
                Name = departmentDto.Name,
            };

            return await _departmentRepository.Create(department);
        }

        public async Task<int> DeleteDepartment(int id)
        {
            if(id <= 0)
            {
                throw new BadRequestException("Id is not valid.");
            }
            var department = await ValidateDepartmentExistence(id);
            return await _departmentRepository.Delete(department);
        }

        public async Task<IEnumerable<GetDepartmentDto>> GetAll()
        {
            var departments = await _departmentRepository.GetAll();
            List<GetDepartmentDto> departmentsDto = [];

            foreach (var department in departments)
            {
                GetDepartmentDto dto = new()
                {
                    Name = department.Name,
                    GroupName = department.GroupName,
                    DepartmentId = department.Id
                };

                departmentsDto.Add(dto);
            }

            return departmentsDto; 
        }

        public async Task<GetDepartmentDto?> GetDepartmentById(int id)
        {
            if(id <= 0)
            {
                throw new BadRequestException("DepartmentId is not valid");
            }

            var department = await ValidateDepartmentExistence(id);
            
            GetDepartmentDto dto = new()
            {
                DepartmentId = department.Id,
                Name = department.Name,
                GroupName = department.GroupName
            };
            return dto;
        }

        public async Task<int> UpdateDepartment(UpdateDepartmentDto departmentDto)
        {
            if(departmentDto is null)
            {
                throw new BadRequestException("Department info is not valid.");
            }
            var department = await ValidateDepartmentExistence(departmentDto.DepartmentId);
            
            department.Name = string.IsNullOrWhiteSpace(departmentDto.Name) ? department.Name : departmentDto.Name;
            department.GroupName = string.IsNullOrWhiteSpace(departmentDto.GroupName) ? department.GroupName : departmentDto.GroupName;
           
            return await _departmentRepository.Update(department);
        }

        private async Task<Department> ValidateDepartmentExistence(int id)
        {
            var existingDepartment = await _departmentRepository.GetById(id) 
                ?? throw new NotFoundException($"Department with Id: {id} was not found.");

            return existingDepartment;
        }
    }
}
