using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.SaleNumber).GreaterThan(0);
        RuleFor(sale => sale.SaleDate).GreaterThan(DateTime.MinValue);
        RuleFor(sale => sale.CustomerId).NotNull().NotEmpty();
        RuleFor(sale => sale.BranchId).NotNull().NotEmpty();
        RuleFor(sale => sale.Amount).GreaterThan(0);
        RuleFor(sale => sale.Discount).GreaterThanOrEqualTo(0);
        RuleFor(sale => sale.Status).NotNull();
        RuleFor(sale => sale.SaleItems).SetValidator(new SaleItemsValidator());

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
