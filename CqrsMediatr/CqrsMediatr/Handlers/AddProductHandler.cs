using CqrsMediatr.Commands;
using CqrsMediatr.DataStore;
using MediatR;

namespace CqrsMediatr.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly FakeDataStore _fakeDataStore;
        public AddProductHandler(FakeDataStore fakeDataStore)
            => _fakeDataStore = fakeDataStore;
        public async Task<Product> Handle(AddProductCommand request,  CancellationToken cancellationToken)
        {
            await _fakeDataStore.AddProduct(request.product);
            return request.product;
        }
    }
}
