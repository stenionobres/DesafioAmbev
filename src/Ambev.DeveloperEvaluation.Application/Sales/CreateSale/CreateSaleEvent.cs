using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Event for notify sale created
/// </summary>
public class CreateSaleEvent : INotification
{
    /// <summary>
    /// Gets the sale id.
    /// </summary>
    public Guid Id { get; }

    public CreateSaleEvent(Guid id)
    {
        Id = id;
    }
}