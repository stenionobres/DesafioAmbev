using Xunit;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Sale entity class.
/// Tests cover validation scenarios.
/// </summary>
public class SaleTests
{
    /// <summary>
    /// Tests that validation passes when all sale properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid sale data")]
    public void Given_ValidSaleData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act
        var result = sale.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when sale properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid sale data")]
    public void Given_InvalidSaleData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var sale = new Sale
        {
            
        };

        // Act
        var result = sale.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that discount ten percent discount are valid.
    /// </summary>
    [Fact(DisplayName = "Ten percent discount should calculates")]
    public void Given_ValidSaleDataWithSixItems_When_CalculatedIsCall_Then_ShouldDataValid()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        sale.Discount = 0;
        sale.SaleItems = SaleTestData.GenerateValidSaleItensForDiscount(2, 3);

        // Act
        sale.Calculate();
        var expectedAmount = 69m;
        var expectedDiscount = 6.9m;
        var expectedAmountWithDiscount = 62.1m;

        // Assert
        Assert.Equal(expectedAmount, sale.Amount);
        Assert.Equal(expectedDiscount, sale.Discount);
        Assert.Equal(expectedAmountWithDiscount, sale.AmountWithDiscount);
    }

    /// <summary>
    /// Tests that discount twenty percent discount are valid.
    /// </summary>
    [Fact(DisplayName = "Twenty percent discount should calculates")]
    public void Given_ValidSaleDataWithTwelveItems_When_CalculatedIsCall_Then_ShouldDataValid()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        sale.Discount = 0;
        sale.SaleItems = SaleTestData.GenerateValidSaleItensForDiscount(2, 6);

        // Act
        sale.Calculate();
        var expectedAmount = 138m;
        var expectedDiscount = 27.6m;
        var expectedAmountWithDiscount = 110.4m;

        // Assert
        Assert.Equal(expectedAmount, sale.Amount);
        Assert.Equal(expectedDiscount, sale.Discount);
        Assert.Equal(expectedAmountWithDiscount, sale.AmountWithDiscount);
    }
}
