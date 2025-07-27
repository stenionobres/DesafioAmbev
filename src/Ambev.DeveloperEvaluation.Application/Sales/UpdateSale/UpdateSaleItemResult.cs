using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Response model item for UpdateSale operation
/// </summary>
public class UpdateSaleItemResult
{
    /// <summary>
    /// Gets or sets the sale item id.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the product id of item.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of item.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price of item.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the total amount of the item
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the discount of the sale
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Gets or sets the Amount applying the discount of the sale item
    /// </summary>
    public decimal AmountWithDiscount { get; set; }

    /// <summary>
    /// The current status of the item
    /// </summary>
    public SaleStatus Status { get; set; }
}
