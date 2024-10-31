using APIExpreso.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace APIExpreso.Services
{
    public class sProducts
    {
        private readonly IMongoCollection<mProductos> _products;


        public sProducts(IConfiguration config)
        {
            var client = new MongoClient("mongodb+srv://fidelmtz8924:sNOQ39NIJp0qx54D@universidad.vti6o.mongodb.net/?retryWrites=true&w=majority&appName=Universidad");
            var database = client.GetDatabase("utscfood");
            _products = database.GetCollection<mProductos>("ProductsCollection");
        }



        public async Task<List<mProductos>> GetProducts() => await _products.Find(_ => true).ToListAsync();

        public async Task<mProductos?> GetProductByID(string id) => await _products.Find(x => x.id == id).FirstOrDefaultAsync();

        public async Task CreateProduct(mProductos producto) => await _products.InsertOneAsync(producto);

        public async Task UpdateProduct(string id, mProductos producto) => await _products.ReplaceOneAsync(x => x.id == id, producto);

        public async Task DeleteProduct(string id) => await _products.DeleteOneAsync(x => x.id == id);
    }
}
