using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.BusinessRules;

public interface IDiscount
{
    bool ShouldApply(IEnumerable<SaleItem> itens);
    decimal Calculate(IEnumerable<SaleItem> itens);
}
