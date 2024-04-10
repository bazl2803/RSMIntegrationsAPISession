namespace Application.Services
{
    using Application.DTOs.ProductCategory;
    using Application.Exceptions;
    using Application.Interfaces;

    using Domain.Interfaces;
    using Domain.Models;

    using Mapster;

    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository repository)
        {
            _productCategoryRepository = repository;
        }

        public async Task<int> CreateProductCategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BadRequestException("ProductCategory info is not valid.");

            ProductCategory productCategory = new() { Name = name };

            return await _productCategoryRepository.Create(productCategory);
        }

        public async Task<int> DeleteProductCategory(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is not valid.");
            }
            var product = await ValidateProductCategoryExistence(id);
            return await _productCategoryRepository.Delete(product);
        }

        public async Task<IEnumerable<GetProductCategoryDto>> GetAll()
        {
            var productCategories = await _productCategoryRepository.GetAll();

            return productCategories.Select(pc => pc.Adapt<GetProductCategoryDto>());
        }

        public async Task<GetProductCategoryDto?> GetProductCategoryById(int id)
        {
            if (id <= 0) throw new BadRequestException("ProductCategoryId is not valid");

            var productCategory = await ValidateProductCategoryExistence(id);

            return productCategory.Adapt<GetProductCategoryDto>();
        }

        public async Task<int> UpdateProductCategory(UpdateProductCategoryDto productCategoryDto)
        {
            if (productCategoryDto is null)
                throw new BadRequestException("ProductCategory info is not valid.");

            var productCategory = await ValidateProductCategoryExistence(productCategoryDto.Id);

            productCategory.Name = string.IsNullOrWhiteSpace(productCategoryDto.Name) ? productCategory.Name : productCategoryDto.Name;

            return await _productCategoryRepository.Update(productCategory);
        }

        private async Task<ProductCategory> ValidateProductCategoryExistence(int id)
        {
            var existingProductCategory = await _productCategoryRepository.GetById(id)
                ?? throw new NotFoundException($"ProductCategory with Id: {id} was not found.");

            return existingProductCategory;
        }
    }
}
