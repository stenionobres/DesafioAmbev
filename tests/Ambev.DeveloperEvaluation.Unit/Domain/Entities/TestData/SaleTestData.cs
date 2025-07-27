using Bogus;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Sale entities.
    /// </summary>
    private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
        .RuleFor(s => s.SaleNumber, f => f.Random.Number(100, 999))
        .RuleFor(s => s.SaleDate, f => f.Date.Between(new DateTime(2025, 6, 1), new DateTime(2025, 6, 30)))
        .RuleFor(s => s.CustomerId, f => f.Random.Guid())
        .RuleFor(s => s.BranchId, f => f.Random.Guid())
        .RuleFor(s => s.Amount, f => f.Random.Decimal(325.15m, 1250.70m))
        .RuleFor(s => s.Discount, f => f.Random.Decimal(0m, 15.50m))
        .RuleFor(s => s.Status, f => f.PickRandom(SaleStatus.NotCancelled, SaleStatus.Cancelled))
        .RuleFor(s => s.CreatedAt, f => f.Date.Between(new DateTime(2025, 7, 1), new DateTime(2025, 7, 15)))
        .RuleFor(s => s.SaleItems, f => SaleItemFaker!.Generate(f.Random.Int(1, 5)));

    /// <summary>
    /// Configures the Faker to generate valid SaleItem entities.
    /// </summary>
    private static readonly Faker<SaleItem> SaleItemFaker = new Faker<SaleItem>()
        .RuleFor(i => i.SaleId, f => f.Random.Guid())
        .RuleFor(i => i.ProductId, f => f.Random.Guid())
        .RuleFor(i => i.Quantity, f => f.Random.Int(1, 15))
        .RuleFor(i => i.UnitPrice, f => f.Random.Decimal(25.15m, 50.70m))
        .RuleFor(i => i.Amount, f => f.Random.Decimal(25.15m, 50.70m))
        .RuleFor(i => i.Discount, f => f.Random.Decimal(0m, 15.50m))
        .RuleFor(i => i.Status, f => f.PickRandom(SaleStatus.NotCancelled, SaleStatus.Cancelled))
        .RuleFor(s => s.CreatedAt, f => f.Date.Between(new DateTime(2025, 7, 1), new DateTime(2025, 7, 15)));

    /// <summary>
    /// Configures the Faker to generate valid SaleItem entities for discount calculator.
    /// </summary>
    private static Faker<SaleItem> SaleItemDiscountFaker(Guid saleId, Guid productId, int quantityProduct) => new Faker<SaleItem>()
        .RuleFor(i => i.SaleId, f => saleId)
        .RuleFor(i => i.ProductId, f => productId)
        .RuleFor(i => i.UnitPrice, f => 11.50m)
        .RuleFor(i => i.Quantity, f => quantityProduct)
        .RuleFor(i => i.Amount, f => 11.50m * quantityProduct)
        .RuleFor(i => i.Status, f => SaleStatus.NotCancelled)
        .RuleFor(s => s.CreatedAt, f => f.Date.Between(new DateTime(2025, 7, 1), new DateTime(2025, 7, 15)));

    /// <summary>
    /// Generates a valid Sale entity with randomized data.
    /// The generated sale will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static Sale GenerateValidSale()
    {
        return SaleFaker.Generate();
    }

    public static List<SaleItem> GenerateValidSaleItensForDiscount(int quantityItens, int quantityProduct)
    {
        var saleId = Guid.NewGuid();
        var productId = Guid.NewGuid();

        return SaleItemDiscountFaker(saleId, productId, quantityProduct).Generate(quantityItens);
    }
}
