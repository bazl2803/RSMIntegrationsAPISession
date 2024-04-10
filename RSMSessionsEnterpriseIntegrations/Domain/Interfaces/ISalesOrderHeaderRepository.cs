
namespace Domain.Interfaces
{
    using Domain.Models;

    public interface ISalesOrderHeaderRepository
    {
        Task<SalesOrderHeader?> GetById(int id);
        Task<IEnumerable<SalesOrderHeader>> GetAll();
        Task<int> Create(SalesOrderHeader salesOrderHeader);
        Task<int> Update(SalesOrderHeader salesOrderHeader);
        Task<int> Delete(SalesOrderHeader salesOrderHeader);
    }
}
