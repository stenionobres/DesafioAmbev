using MediatR;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.Application.Email;

/// <summary>
/// Captures sale created and simules a email sent
/// </summary>
public class CreateSaleEmailHandler : INotificationHandler<CreateSaleEvent>
{
    public Task Handle(CreateSaleEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Enviando e-mail para o cliente sobre a criação da venda {notification.Id}.");
        return Task.CompletedTask;
    }
}
