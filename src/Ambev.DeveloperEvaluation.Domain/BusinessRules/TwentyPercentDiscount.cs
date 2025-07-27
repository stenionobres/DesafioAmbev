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
        var amount = itens.Sum(i => i.UnitPrice * i.Quantity);
        return amount * Discount;
    }
}
