using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for sale creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - SaleNumber: Must greater than zero
    /// - SaleDate: Required, must greater than mindate
    /// - CustomerId: Required
    /// - BranchId: Required
    /// - Amount: Must greater than zero
    /// - Status: Required
    /// - SaleItem-ProductId: Required
    /// - SaleItem-Quantity: Must greater than zero
    /// - SaleItem-UnitPrice: Must greater than zero
    /// - SaleItem-Amount: Must greater than zero
    /// - SaleItem-Status: Required
    /// </remarks>
    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.SaleNumber).GreaterThan(0);
        RuleFor(sale => sale.SaleDate).GreaterThan(DateTime.MinValue);
        RuleFor(sale => sale.CustomerId).NotNull().NotEmpty();
        RuleFor(sale => sale.BranchId).NotNull().NotEmpty();
        RuleFor(sale => sale.Amount).GreaterThan(0);
        RuleFor(sale => sale.Discount).GreaterThanOrEqualTo(0);
        RuleFor(sale => sale.Status).NotNull();
        RuleFor(sale => sale.SaleItems).NotNull().Must(x => x.Count > 0);

        RuleForEach(x => x.SaleItems).ChildRules(item =>
        {
            item.RuleFor(x => x.ProductId).NotNull().NotEmpty();
            item.RuleFor(x => x.Quantity).GreaterThan(0);
            item.RuleFor(x => x.UnitPrice).GreaterThan(0);
            item.RuleFor(x => x.Amount).GreaterThan(0);
            item.RuleFor(x => x.Discount).GreaterThanOrEqualTo(0);
            item.RuleFor(x => x.Status).NotNull();
        });
    }
}