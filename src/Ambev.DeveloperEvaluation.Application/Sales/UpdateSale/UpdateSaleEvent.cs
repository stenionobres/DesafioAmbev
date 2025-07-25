using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Event for notify sale updated
/// </summary>
public class UpdateSaleEvent : INotification
{
    /// <summary>
    /// Gets the sale id.
    /// </summary>
    public Guid Id { get; }

    public UpdateSaleEvent(Guid id)
    {
        Id = id;
    }
}
