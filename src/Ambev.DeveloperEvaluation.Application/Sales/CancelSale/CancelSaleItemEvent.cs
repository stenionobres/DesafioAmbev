using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Event for notify sale item canceled
/// </summary>
public class CancelSaleItemEvent : INotification
{
    /// <summary>
    /// Gets the sale id.
    /// </summary>
    public Guid SaleId { get; }

    /// <summary>
    /// Gets the sale item id.
    /// </summary>
    public Guid SaleItemId { get; }

    public CancelSaleItemEvent(Guid saleId, Guid saleItemId)
    {
        SaleId = saleId;
        SaleItemId = saleItemId;
    }
}
