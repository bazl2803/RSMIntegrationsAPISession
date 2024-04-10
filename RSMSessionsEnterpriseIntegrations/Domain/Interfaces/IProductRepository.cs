namespace Domain.Interfaces
{
    using Domain.Models;

    public interface IProductRepository
    {
        Task<Product?> GetById(int id);
        Task<IEnumerable<Product>> GetAll();
        Task<int> Create(Product product);
        Task<int> Update(Product product);
        Task<int> Delete(Product product);
    }
}
