using Xunit;
using Ambev.DeveloperEvaluation.Domain.BusinessRules;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

namespace Ambev.DeveloperEvaluation.Unit.Domain.BusinessRules;

/// <summary>
/// Contains unit tests for the TenPercentDiscount class.
/// </summary>
public class TenPercentDiscountTests
{
    private readonly TenPercentDiscount _tenPercentDiscount;

    public TenPercentDiscountTests()
    {
        _tenPercentDiscount = new TenPercentDiscount();
    }

    /// <summary>
    /// Tests if should apply discount for one sale item without minimum quantity
    /// </summary>
    [Fact(DisplayName = "Should not apply discount for one sale item without minimum quantity")]
    public void Given_OneSaleItem_When_QuantityIsBelowTheMinimum_Then_DiscountShouldntApply()
    {
        // Arrange
        var saleItens = SaleTestData.GenerateValidSaleItensForDiscount(1, 1);

        // Act
        var result = _tenPercentDiscount.ShouldApply(saleItens);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests if should apply discount for one sale item with minimum quantity
    /// </summary>
    [Fact(DisplayName = "Should apply discount for one sale item with minimum quantity")]
    public void Given_OneSaleItem_When_QuantityIsMoreTheMinimum_Then_DiscountShouldApply()
    {
        // Arrange
        var saleItens = SaleTestData.GenerateValidSaleItensForDiscount(1, 5);

        // Act
        var result = _tenPercentDiscount.ShouldApply(saleItens);

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Tests if should apply discount for many sale item without minimum quantity
    /// </summary>
    [Fact(DisplayName = "Should not apply discount for many sale item without minimum quantity")]
    public void Given_ManySaleItem_When_QuantityIsBelowTheMinimum_Then_DiscountShouldntApply()
    {
        // Arrange
        var saleItens = SaleTestData.GenerateValidSaleItensForDiscount(2, 1);

        // Act
        var result = _tenPercentDiscount.ShouldApply(saleItens);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests if should apply discount for many sale item with minimum quantity
    /// </summary>
    [Fact(DisplayName = "Should apply discount for many sale item with minimum quantity")]
    public void Given_ManySaleItem_When_QuantityIsMoreTheMinimum_Then_DiscountShouldApply()
    {
        // Arrange
        var saleItens = SaleTestData.GenerateValidSaleItensForDiscount(2, 3);

        // Act
        var result = _tenPercentDiscount.ShouldApply(saleItens);

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Tests if discount is calculated for one sale item
    /// </summary>
    [Fact(DisplayName = "Should calculate discount for one sale item")]
    public void Given_OneSaleItem_When_CalculateIsCall_Then_DiscountIsCalculated()
    {
        // Arrange
        var saleItens = SaleTestData.GenerateValidSaleItensForDiscount(1, 5);

        // Act
        var result = _tenPercentDiscount.Calculate(saleItens);
        var expectedValue = 5.75m;

        // Assert
        Assert.Equal(expectedValue, result);
    }

    /// <summary>
    /// Tests if discount is calculated for many sale item
    /// </summary>
    [Fact(DisplayName = "Should calculate discount for many sale item")]
    public void Given_ManySaleItem_When_CalculateIsCall_Then_DiscountIsCalculated()
    {
        // Arrange
        var saleItens = SaleTestData.GenerateValidSaleItensForDiscount(2, 3);

        // Act
        var result = _tenPercentDiscount.Calculate(saleItens);
        var expectedValue = 6.9m;

        // Assert
        Assert.Equal(expectedValue, result);
    }
}
