using CqrsMediatr.DataStore;
using CqrsMediatr.Queries;
using MediatR;

namespace CqrsMediatr.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly FakeDataStore _fakeDataStore;
        public GetProductsHandler (FakeDataStore fakeDataStore) 
            => _fakeDataStore = fakeDataStore;
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
            => await _fakeDataStore.GetAllProduct();
    }
}
