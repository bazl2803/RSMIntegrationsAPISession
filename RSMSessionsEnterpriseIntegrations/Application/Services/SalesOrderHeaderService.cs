
namespace Application.Services
{
    using Application.DTOs.SalesOrderHeader;
    using Application.Exceptions;
    using Application.Interfaces;
    using Application.Validators;

    using Domain.Interfaces;
    using Domain.Models;

    using Mapster;

    public class SalesOrderHeaderService : ISalesOrderHeaderService
    {
        private readonly ISalesOrderHeaderRepository _salesOrderHeaderRepository;

        public SalesOrderHeaderService(ISalesOrderHeaderRepository repository)
        {
            _salesOrderHeaderRepository = repository;
        }

        public async Task<int> CreateSalesOrderHeader(CreateSalesOrderHeaderDto salesOrderHeaderDto)
        {
            var validator = new CreateSalesOrderHeaderDtoValidator();
            var validationResult = validator.Validate(salesOrderHeaderDto);

            if (!validationResult.IsValid)
                throw new BadRequestException("SalesOrderHeader info is not valid.");

            SalesOrderHeader salesOrderHeader = salesOrderHeaderDto.Adapt<SalesOrderHeader>();
            return await _salesOrderHeaderRepository.Create(salesOrderHeader);
        }

        public async Task<int> DeleteSalesOrderHeader(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is not valid.");
            }
            var salesOrderHeader = await ValidateSalesOrderHeaderExistence(id);
            return await _salesOrderHeaderRepository.Delete(salesOrderHeader);
        }

        public async Task<IEnumerable<GetSalesOrderHeaderDto>> GetAll()
        {
            var salesOrderHeaders = await _salesOrderHeaderRepository.GetAll();

            return salesOrderHeaders.Select(soh => soh.Adapt<GetSalesOrderHeaderDto>());
        }

        public async Task<GetSalesOrderHeaderDto?> GetSalesOrderHeaderById(int id)
        {
            if (id <= 0) throw new BadRequestException("SalesOrderId is not valid");

            var salesOrderHeader = await ValidateSalesOrderHeaderExistence(id);

            return salesOrderHeader.Adapt<GetSalesOrderHeaderDto>();
        }

        public async Task<int> UpdateSalesOrderHeader(UpdateSalesOrderHeaderDto salesOrderHeaderDto)
        {
            var validator = new UpdateSalesOrderHeaderDtoValidator();
            var validationResult = validator.Validate(salesOrderHeaderDto);

            if (!validationResult.IsValid)
                throw new BadRequestException("Product info is not valid.");

            var product = await ValidateSalesOrderHeaderExistence(salesOrderHeaderDto.Id);

            salesOrderHeaderDto.Adapt(product);
            return await _salesOrderHeaderRepository.Update(product);
        }

        private async Task<SalesOrderHeader> ValidateSalesOrderHeaderExistence(int id)
        {
            var existingSalesOrderHeader = await _salesOrderHeaderRepository.GetById(id)
                ?? throw new NotFoundException($"SalesOrderHeader with Id: {id} was not found.");

            return existingSalesOrderHeader;
        }
    }
}
