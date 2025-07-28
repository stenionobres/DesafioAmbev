using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.BusinessRules;

/// <summary>
/// Interface for discount rules
/// </summary>
public interface IDiscount
{
    bool ShouldApply(IEnumerable<SaleItem> itens);
    decimal Calculate(IEnumerable<SaleItem> itens);
}
