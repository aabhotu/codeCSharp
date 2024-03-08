using MediatR;

namespace CqrsMediatr.Commands
{
    public record AddProductCommand(Product product) :IRequest<Product>
    {
    }
}
