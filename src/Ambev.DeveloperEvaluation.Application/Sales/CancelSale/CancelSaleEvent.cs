using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Event for notify sale canceled
/// </summary>
public class CancelSaleEvent : INotification
{
    /// <summary>
    /// Gets the sale id.
    /// </summary>
    public Guid Id { get; }

    public CancelSaleEvent(Guid id)
    {
        Id = id;
    }
}
