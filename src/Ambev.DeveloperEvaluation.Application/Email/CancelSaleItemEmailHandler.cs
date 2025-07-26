using MediatR;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

namespace Ambev.DeveloperEvaluation.Application.Email;

/// <summary>
/// Captures sale item canceled and simules a email sent
/// </summary>
public class CancelSaleItemEmailHandler : INotificationHandler<CancelSaleItemEvent>
{
    public Task Handle(CancelSaleItemEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Enviando e-mail para o cliente sobre o cancelamento do item {notification.SaleItemId} da venda {notification.SaleId}");
        return Task.CompletedTask;
    }
}
