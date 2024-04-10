using Domain.Models;

namespace Domain.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<ProductCategory?> GetById(int id);
        Task<IEnumerable<ProductCategory>> GetAll();
        Task<int> Create(ProductCategory productCategory);
        Task<int> Update(ProductCategory productCategory);
        Task<int> Delete(ProductCategory productCategory);
    }
}
