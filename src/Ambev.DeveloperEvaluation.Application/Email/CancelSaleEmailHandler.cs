using MediatR;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

namespace Ambev.DeveloperEvaluation.Application.Email;

/// <summary>
/// Captures sale canceled and simules a email sent
/// </summary>
public class CancelSaleEmailHandler : INotificationHandler<CancelSaleEvent>
{
    public Task Handle(CancelSaleEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Enviando e-mail para o cliente sobre o cancelamento da venda {notification.Id}.");
        return Task.CompletedTask;
    }
}
