using Xunit;
using Ambev.DeveloperEvaluation.Domain.BusinessRules;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

namespace Ambev.DeveloperEvaluation.Unit.Domain.BusinessRules;

/// <summary>
/// Contains unit tests for the DiscountCalculator class.
/// </summary>
public class DiscountCalculatorTests
{
    private readonly DiscountCalculator _discountCalculator;

    public DiscountCalculatorTests()
    {
        _discountCalculator = new DiscountCalculator();
    }

    /// <summary>
    /// Tests if discounts calculates is zero
    /// </summary>
    [Fact(DisplayName = "Should calculates a zero discount for sale itens without minimum quantity")]
    public void Given_ManySaleItem_When_QuantityIsBelowTheMinimum_Then_DiscountIsZero()
    {
        // Arrange
        var saleItens = SaleTestData.GenerateValidSaleItensForDiscount(2, 1);

        // Act
        var result = _discountCalculator.Calculate(saleItens);
        var expectedValue = 0m;

        // Assert
        Assert.Equal(expectedValue, result);
    }

    /// <summary>
    /// Tests if discounts calculates is ten percent
    /// </summary>
    [Fact(DisplayName = "Should calculates a ten percent discount for sale itens with correct quantity")]
    public void Given_ManySaleItem_When_TotalQuantityIsCorrect_Then_DiscountIsTenPercent()
    {
        // Arrange
        var saleItens = SaleTestData.GenerateValidSaleItensForDiscount(2, 3);

        // Act
        var result = _discountCalculator.Calculate(saleItens);
        var expectedValue = 6.9m;

        // Assert
        Assert.Equal(expectedValue, result);
    }

    /// <summary>
    /// Tests if discounts calculates is twenty percent
    /// </summary>
    [Fact(DisplayName = "Should calculates a twenty percent discount for sale itens with correct quantity")]
    public void Given_ManySaleItem_When_TotalQuantityIsCorrect_Then_DiscountIsTwentyPercent()
    {
        // Arrange
        var saleItens = SaleTestData.GenerateValidSaleItensForDiscount(2, 7);

        // Act
        var result = _discountCalculator.Calculate(saleItens);
        var expectedValue = 32.2m;

        // Assert
        Assert.Equal(expectedValue, result);
    }
}
