using Xunit;
using MediatR;
using AutoMapper;
using NSubstitute;
using FluentAssertions;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="CreateSaleHandler"/> class.
/// </summary>
public class CreateSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly CreateSaleHandler _handler;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleHandlerTests"/> class.
    /// Sets up the test dependencies and creates fake data generators.
    /// </summary>
    public CreateSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _mapper = Substitute.For<IMapper>();
        _mediator = Substitute.For<IMediator>();
        _handler = new CreateSaleHandler(_saleRepository, _mapper, _mediator);
    }

    /// <summary>
    /// Tests that a valid sale creation request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid sale data When creating sale Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();
        var sale = new Sale
        {
            Id = Guid.NewGuid(),
            SaleNumber = command.SaleNumber,
            SaleDate = command.SaleDate,
            CustomerId = command.CustomerId,
            BranchId = command.BranchId,
            Amount = command.Amount,
            Discount = command.Discount,
            Status = command.Status,
        };

        foreach (var commandSaleItem in command.SaleItems)
        {
            sale.SaleItems.Add(new SaleItem()
            {
                ProductId = commandSaleItem.ProductId,
                Quantity = commandSaleItem.Quantity,
                UnitPrice = commandSaleItem.UnitPrice,
                Amount = commandSaleItem.Amount,
                Discount = commandSaleItem.Discount,
                Status = commandSaleItem.Status
            });
        }

        var result = new CreateSaleResult
        {
            Id = sale.Id,
        };

        _mapper.Map<Sale>(command).Returns(sale);
        _mapper.Map<CreateSaleResult>(sale).Returns(result);

        _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(sale);

        // When
        var createSaleResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        createSaleResult.Should().NotBeNull();
        createSaleResult.Id.Should().Be(sale.Id);
        await _saleRepository.Received(1).CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that an invalid sale creation request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid sale data When creating sale Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var command = new CreateSaleCommand(); // Empty command will fail validation

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

    /// <summary>
    /// Tests that the mapper is called with the correct command.
    /// </summary>
    [Fact(DisplayName = "Given valid command When handling Then maps command to sale entity")]
    public async Task Handle_ValidRequest_MapsCommandToUser()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();
        var sale = new Sale
        {
            Id = Guid.NewGuid(),
            SaleNumber = command.SaleNumber,
            SaleDate = command.SaleDate,
            CustomerId = command.CustomerId,
            BranchId = command.BranchId,
            Amount = command.Amount,
            Discount = command.Discount,
            Status = command.Status,
        };

        foreach (var commandSaleItem in command.SaleItems)
        {
            sale.SaleItems.Add(new SaleItem()
            {
                ProductId = commandSaleItem.ProductId,
                Quantity = commandSaleItem.Quantity,
                UnitPrice = commandSaleItem.UnitPrice,
                Amount = commandSaleItem.Amount,
                Discount = commandSaleItem.Discount,
                Status = commandSaleItem.Status
            });
        }

        var result = new CreateSaleResult
        {
            Id = sale.Id,
        };

        _mapper.Map<Sale>(command).Returns(sale);
        _mapper.Map<CreateSaleResult>(sale).Returns(result);
        _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(sale);

        // When
        await _handler.Handle(command, CancellationToken.None);

        // Then
        _mapper.Received(1).Map<Sale>(Arg.Is<CreateSaleCommand>(c =>
            c.SaleNumber == command.SaleNumber &&
            c.SaleDate == command.SaleDate &&
            c.CustomerId == command.CustomerId &&
            c.BranchId == command.BranchId &&
            c.Amount == command.Amount &&
            c.Discount == command.Discount &&
            c.Status == command.Status));
    }
}
