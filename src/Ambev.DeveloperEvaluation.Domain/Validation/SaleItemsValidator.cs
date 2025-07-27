using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleItemsValidator : AbstractValidator<IEnumerable<SaleItem>>
{
    private const decimal MaxItems = 20;

    public SaleItemsValidator()
    {
        RuleFor(item => item).NotNull()
                             .WithMessage("The sale item should be informed.")
                             .Must(x => x.Count() > 0)
                             .WithMessage("The sale item should be informed.")
                             .Must(BeValidQuantity)
                             .WithMessage($"A maximum of {MaxItems} items of the same product are allowed.");
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
