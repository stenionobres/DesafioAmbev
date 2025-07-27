using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleItemsValidator : AbstractValidator<IEnumerable<SaleItem>>
{
    private const decimal MaxItems = 20;

    public SaleItemsValidator()
    {
        RuleFor(item => item).NotNull()
                             .Must(x => x.Count() > 0)
                             .Must(BeValidQuantity);
    }

    private bool BeValidQuantity(IEnumerable<SaleItem> saleItems)
    {
        var groupedSaleItems = saleItems.GroupBy(i => i.ProductId)
                                        .Select(g => g.ToList())
                                        .ToList();

        foreach (var group in groupedSaleItems)
        {
            var totalQuantity = group.Sum(g => g.Quantity);
            if (totalQuantity > MaxItems)
                return false;
        }
        
        return true;
    }
}
