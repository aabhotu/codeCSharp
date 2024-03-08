using CqrsMediatr.Commands;
using CqrsMediatr.DataStore;
using MediatR;

namespace CqrsMediatr.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly FakeDataStore _fakeDataStore;
        public UpdateProductHandler(FakeDataStore fakeDataStore) 
            => _fakeDataStore = fakeDataStore;
        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.UpdateProduct(request.product);
            return request.product;
        }
    }
}
