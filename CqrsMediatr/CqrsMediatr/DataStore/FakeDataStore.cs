namespace CqrsMediatr.DataStore
{
    public class FakeDataStore
    {
        private static List<Product> _products;
        public FakeDataStore()
        {
            _products = new List<Product>() { 
                new Product{Id =1, Name="Product 1"},
                new Product{Id =2, Name="Product 2"},
                new Product{Id =3, Name="Product 3"},
            };
        }
        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }
        public async Task<IEnumerable<Product>> GetAllProduct() 
            => await Task.FromResult(_products);
        public async Task<Product> GetProductById(int id)
            => await Task.FromResult(_products.Single(p =>  p.Id == id));
        public async Task UpdateProduct(Product product)
        {
            _products.Single(p=> p.Id == product.Id).Name = product.Name;
            await Task.CompletedTask;
        }
        public async Task EventOccured(Product product, string evt)
        {
            _products.Single(p=> p.Id == product.Id).Name =$" {product.Name} evt: {evt}";
            await Task.CompletedTask;
        }
    }
}
