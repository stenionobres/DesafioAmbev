using Xunit;
using FluentValidation.TestHelper;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the SaleItemsValidator class.
/// </summary>
public class SaleItemsValidatorTests
{
    private readonly SaleItemsValidator _validator;

    public SaleItemsValidatorTests()
    {
        _validator = new SaleItemsValidator();
    }

    /// <summary>
    /// Tests that validation passes for various sale items.
    /// </summary>
    [Fact(DisplayName = "Valid sale items should pass validation")]
    public void Given_ManySaleItems_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var saleItems = SaleTestData.GenerateValidSaleItensForDiscount(3, 2);

        // Act
        var result = _validator.TestValidate(saleItems);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that validation not pass for more than twenty items.
    /// </summary>
    [Fact(DisplayName = "Valid sale items should not pass validation")]
    public void Given_ManySaleItemsWithMoreThanTwentyItems_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var saleItems = SaleTestData.GenerateValidSaleItensForDiscount(2, 21);

        // Act
        var result = _validator.TestValidate(saleItems);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x);
    }
}
