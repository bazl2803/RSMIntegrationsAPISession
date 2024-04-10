
namespace Application.Interfaces
{
    using Application.DTOs.ProductCategory;

    public interface IProductCategoryService
    {
        Task<GetProductCategoryDto?> GetProductCategoryById(int id);
        Task<IEnumerable<GetProductCategoryDto>> GetAll();
        Task<int> CreateProductCategory(string name);
        Task<int> UpdateProductCategory(UpdateProductCategoryDto productDto);
        Task<int> DeleteProductCategory(int id);
    }
}
