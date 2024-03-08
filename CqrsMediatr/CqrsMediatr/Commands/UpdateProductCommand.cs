using MediatR;

namespace CqrsMediatr.Commands
{
    public record UpdateProductCommand(Product product) : IRequest<Product>
    {
    }
}
