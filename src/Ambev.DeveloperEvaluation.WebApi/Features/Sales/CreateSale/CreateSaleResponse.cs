using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// API response model for CreateSale operation
    /// </summary>
    public class CreateSaleResponse
    {
        /// <summary>
        /// The unique identifier of the created sale
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the sale number.
        /// </summary>
        public int SaleNumber { get; set; }

        /// <summary>
        /// Gets or sets the sale date.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Gets or sets the customer id of sale.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the sale
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the discount of the sale
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Gets or sets the Amount applying the discount of the sale
        /// </summary>
        public decimal AmountWithDiscount { get; set; }

        /// <summary>
        /// The current status of the sale
        /// </summary>
        public SaleStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the itens of the sale
        /// </summary>
        public List<CreateSaleItemResponse> SaleItems { get; set; } = new List<CreateSaleItemResponse>();
    }
}
