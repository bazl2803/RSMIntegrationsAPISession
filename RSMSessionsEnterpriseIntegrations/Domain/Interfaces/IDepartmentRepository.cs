namespace Domain.Interfaces
{
    using Domain.Models;

    public interface IDepartmentRepository
    {
        Task<Department?> GetById(int id);
        Task<IEnumerable<Department>> GetAll();
        Task<int> Create(Department department);
        Task<int> Update(Department department);
        Task<int> Delete(Department department);
    }
}
