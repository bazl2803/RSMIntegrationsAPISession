using Application.DTOs.SalesOrderHeader;

namespace Application.Interfaces
{
    public interface ISalesOrderHeaderService
    {
        Task<GetSalesOrderHeaderDto?> GetSalesOrderHeaderById(int id);
        Task<IEnumerable<GetSalesOrderHeaderDto>> GetAll();
        Task<int> CreateSalesOrderHeader(CreateSalesOrderHeaderDto salesOrderHeaderDto);
        Task<int> UpdateSalesOrderHeader(UpdateSalesOrderHeaderDto salesOrderHeaderDto);
        Task<int> DeleteSalesOrderHeader(int id);
    }
}
