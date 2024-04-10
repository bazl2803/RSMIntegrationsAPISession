namespace Application.Services
{
    using Application.DTOs.Product;
    using Application.Exceptions;
    using Application.Interfaces;
    using Application.Validators;

    using Domain.Interfaces;
    using Domain.Models;

    using Mapster;

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository repository)
        {
            _productRepository = repository;
        }

        public async Task<int> CreateProduct(CreateProductDto productDto)
        {
            var validator = new CreateProductDtoValidator();
            var validationResult = validator.Validate(productDto);

            if (!validationResult.IsValid)
                throw new BadRequestException("Product info is not valid.");

            Product product = productDto.Adapt<Product>();
            return await _productRepository.Create(product);
        }

        public async Task<int> DeleteProduct(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is not valid.");
            }
            var product = await ValidateProductExistence(id);
            return await _productRepository.Delete(product);
        }

        public async Task<IEnumerable<GetProductDto>> GetAll()
        {
            var products = await _productRepository.GetAll();

            return products.Select(product => product.Adapt<GetProductDto>());
        }

        public async Task<GetProductDto?> GetProductById(int id)
        {
            if (id <= 0) throw new BadRequestException("ProductId is not valid");

            var product = await ValidateProductExistence(id);

            return product.Adapt<GetProductDto>();
        }

        public async Task<int> UpdateProduct(UpdateProductDto productDto)
        {
            var validator = new UpdateProductDtoValidator();
            var validationResult = validator.Validate(productDto);

            if (!validationResult.IsValid)
                throw new BadRequestException("Product info is not valid.");

            var product = await ValidateProductExistence(productDto.Id);

            productDto.Adapt(product);
            return await _productRepository.Update(product);
        }

        private async Task<Product> ValidateProductExistence(int id)
        {
            var existingProduct = await _productRepository.GetById(id)
                ?? throw new NotFoundException($"Product with Id: {id} was not found.");

            return existingProduct;
        }
    }
}
