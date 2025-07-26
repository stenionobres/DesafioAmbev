using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        /// <summary>
        /// Gets or sets the sale id of item.
        /// </summary>
        public Guid SaleId { get; set; }

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
        /// Gets or sets the Amount applying the discount of the item
        /// </summary>
        public decimal AmountWithDiscount { get; set; }

        /// <summary>
        /// The current status of the item
        /// </summary>
        public SaleStatus Status { get; set; }

        /// <summary>
        /// Gets the date and time when the sale item was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time of the last update to the sale item information.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        public SaleItem()
        {
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Property that determines whether the sale item is canceled or not.
        /// </summary>
        public bool IsCanceled => SaleStatus.Cancelled.Equals(Status);
    }
}
