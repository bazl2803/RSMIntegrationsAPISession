namespace Application.Validators
{
    using Application.DTOs.SalesOrderHeader;
    using FluentValidation;

    public class UpdateSalesOrderHeaderDtoValidator : AbstractValidator<UpdateSalesOrderHeaderDto>
    {
        public UpdateSalesOrderHeaderDtoValidator()
        {
            RuleFor(dto => dto.Id).NotEmpty();
            RuleFor(dto => dto.RevisionNumber).NotEmpty();
            RuleFor(dto => dto.OrderDate).NotEmpty();
            RuleFor(dto => dto.DueDate).NotEmpty().GreaterThanOrEqualTo(dto => dto.OrderDate);
            RuleFor(dto => dto.Status).NotEmpty();
            RuleFor(dto => dto.CustomerId).NotEmpty();
            RuleFor(dto => dto.SalesPersonID).NotEmpty();
            RuleFor(dto => dto.BillToAddressID).NotEmpty();
            RuleFor(dto => dto.ShipToAddressID).NotEmpty();
            RuleFor(dto => dto.ShipMethodID).NotEmpty();
            RuleFor(dto => dto.Subtotal).NotEmpty().GreaterThan(0);
            RuleFor(dto => dto.TaxAmt).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(dto => dto.Freight).NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}
