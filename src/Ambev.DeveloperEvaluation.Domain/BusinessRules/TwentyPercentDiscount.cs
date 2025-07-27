using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.BusinessRules;

public class TwentyPercentDiscount : IDiscount
{
    private const decimal Discount = 0.20m;

    public bool ShouldApply(IEnumerable<SaleItem> itens)
    {
        var quantity = itens.Sum(i => i.Quantity);
        return quantity >= 10 && quantity <= 20;
    }

    public decimal Calculate(IEnumerable<SaleItem> itens)
    {
        var discount = 0m;

        foreach (var item in itens)
        {
            item.Amount = item.UnitPrice * item.Quantity;
            item.Discount = item.Amount * Discount;
            item.AmountWithDiscount = item.Amount - item.Discount;
            discount += item.Discount;
        }

        return discount;
    }
}
