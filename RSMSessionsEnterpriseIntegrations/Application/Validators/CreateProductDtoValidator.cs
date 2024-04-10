﻿namespace Application.Validators
{
    using Application.DTOs.Product;
    using FluentValidation;

    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty();
            RuleFor(dto => dto.ProductNumber).NotEmpty();
            RuleFor(dto => dto.SafetyStockLevel).GreaterThan((short)-1);
            RuleFor(dto => dto.ReorderPoint).GreaterThan((short)-1);
            RuleFor(dto => dto.StandardCost).GreaterThan(-1);
            RuleFor(dto => dto.ListPrice).GreaterThan(-1);
            RuleFor(dto => dto.DaysToManufacture).GreaterThan(-1);
            RuleFor(dto => dto.SellStartDate).NotEmpty();
        }
    }
}