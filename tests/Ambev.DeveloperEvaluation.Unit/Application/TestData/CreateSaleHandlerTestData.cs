using Bogus;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class CreateSaleHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Sale commands.
    /// </summary>
    private static readonly Faker<CreateSaleCommand> createSaleHandlerFaker = new Faker<CreateSaleCommand>()
        .RuleFor(s => s.SaleNumber, f => f.Random.Number(100, 999))
        .RuleFor(s => s.SaleDate, f => f.Date.Between(new DateTime(2025, 6, 1), new DateTime(2025, 6, 30)))
        .RuleFor(s => s.CustomerId, f => f.Random.Guid())
        .RuleFor(s => s.BranchId, f => f.Random.Guid())
        .RuleFor(s => s.Amount, f => f.Random.Decimal(325.15m, 1250.70m))
        .RuleFor(s => s.Discount, f => f.Random.Decimal(0m, 15.50m))
        .RuleFor(s => s.Status, SaleStatus.NotCancelled)
        .RuleFor(s => s.SaleItems, f => SaleItemFaker!.Generate(f.Random.Int(1, 5)));

    /// <summary>
    /// Configures the Faker to generate valid Sale Item commands.
    /// </summary>
    private static readonly Faker<CreateSaleItemCommand> SaleItemFaker = new Faker<CreateSaleItemCommand>()
        .RuleFor(i => i.ProductId, f => f.Random.Guid())
        .RuleFor(i => i.Quantity, f => f.Random.Int(1, 15))
        .RuleFor(i => i.UnitPrice, f => f.Random.Decimal(25.15m, 50.70m))
        .RuleFor(i => i.Amount, f => f.Random.Decimal(25.15m, 50.70m))
        .RuleFor(i => i.Discount, f => f.Random.Decimal(0m, 15.50m))
        .RuleFor(i => i.Status, f => f.PickRandom(SaleStatus.NotCancelled, SaleStatus.Cancelled));

    /// <summary>
    /// Generates a valid Sale command with randomized data.
    /// </summary>
    /// <returns>A valid Sale command entity with randomly generated data.</returns>
    public static CreateSaleCommand GenerateValidCommand()
    {
        return createSaleHandlerFaker.Generate();
    }
}
