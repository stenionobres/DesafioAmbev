using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.BusinessRules;

public class TenPercentDiscount : IDiscount
{
    private const decimal Discount = 0.10m;

    public bool ShouldApply(IEnumerable<SaleItem> itens)
    {
        var quantity = itens.Sum(i => i.Quantity);
        return quantity >= 4 && quantity < 10;
    }

    public decimal Calculate(IEnumerable<SaleItem> itens)
    {
        var amount = itens.Sum(i => i.UnitPrice * i.Quantity);
        return amount * Discount;
    }
}
