using Bogus;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class DeleteSaleHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Sale commands.
    /// </summary>
    private static readonly Faker<DeleteSaleCommand> deleteSaleHandlerFaker = new Faker<DeleteSaleCommand>()
        .RuleFor(s => s.Id, f => f.Random.Guid());

    /// <summary>
    /// Generates a valid Sale command with randomized data.
    /// </summary>
    /// <returns>A valid Sale command entity with randomly generated data.</returns>
    public static DeleteSaleCommand GenerateValidCommand()
    {
        return deleteSaleHandlerFaker.Generate();
    }
}
