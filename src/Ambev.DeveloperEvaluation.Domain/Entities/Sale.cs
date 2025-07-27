using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.BusinessRules;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sale in the system.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Sale : BaseEntity
{
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
    /// Gets or sets the branch id where the sale was made.
    /// </summary>
    public Guid BranchId { get; set; }

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
    /// Gets or sets the current status of the sale
    /// </summary>
    public SaleStatus Status { get; set; }

    /// <summary>
    /// Gets the date and time when the sale was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the sale information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Gets or sets the itens of the sale
    /// </summary>
    public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

    private readonly DiscountCalculator _discountCalculator;

    public Sale()
    {
        CreatedAt = DateTime.UtcNow;
        _discountCalculator = new DiscountCalculator();
    }

    /// <summary>
    /// Performs validation of the user entity using the UserValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Property that determines whether the sale is canceled or not.
    /// </summary>
    public bool IsCanceled => SaleStatus.Cancelled.Equals(Status);

    /// <summary>
    /// Method that calculates the sale discount and sale itens discount
    /// based in the follow rules:
    /// 4+ items: 10% discount
    /// 10-20 items: 20% discount
    /// </summary>
    public void Calculate()
    {
        SaleItems.ForEach(i => i.AmountWithDiscount = i.Amount);
        Amount = SaleItems.Where(i => SaleStatus.NotCancelled.Equals(i.Status))
                          .Sum(i => i.UnitPrice * i.Quantity);

        var groupedSaleItems = SaleItems.Where(i => SaleStatus.NotCancelled.Equals(i.Status))
                                        .GroupBy(i => i.ProductId)
                                        .Select(g => g.ToList()) 
                                        .ToList();

        foreach (var group in groupedSaleItems)
        {
            var discount = _discountCalculator.Calculate(group);

            Discount += discount;
        }

        AmountWithDiscount = Amount - Discount;
    }
}
