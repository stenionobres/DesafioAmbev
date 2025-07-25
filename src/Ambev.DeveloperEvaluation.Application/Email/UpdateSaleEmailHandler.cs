using MediatR;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

namespace Ambev.DeveloperEvaluation.Application.Email;

/// <summary>
/// Captures the sale update and simulates sending an email
/// </summary>
public class UpdateSaleEmailHandler : INotificationHandler<UpdateSaleEvent>
{
    public Task Handle(UpdateSaleEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Enviando e-mail para o cliente sobre a atualização da venda {notification.Id}.");
        return Task.CompletedTask;
    }
}
