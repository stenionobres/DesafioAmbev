using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.BusinessRules;

/// <summary>
/// Classes that apply discount rules
/// </summary>
public class DiscountCalculator
{
    private readonly List<IDiscount> _rules;

    public DiscountCalculator()
    {
        _rules = new List<IDiscount>
        {
            new TenPercentDiscount(),
            new TwentyPercentDiscount()
        };
    }

    public decimal Calculate(IEnumerable<SaleItem> itens)
    {
        foreach (var rule in _rules)
        {
            if (rule.ShouldApply(itens))
                return rule.Calculate(itens);
        }

        return 0;
    }
}