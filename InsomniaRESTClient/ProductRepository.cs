using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsomniaRESTClient
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> products = new ();
        public ProductRepository()
        {
            products.Add(new Product
            {
                Id = 1,
                Code = "P0001",
                Name = "DELL Laptop"
            });

            products.Add(new Product
            {
                Id = 2,
                Code = "P0002",
                Name = "Logitech Wireless Mouse"
            });

            products.Add(new Product
            {
                Id = 3,
                Code = "P0003",
                Name = "HP Printer"
            });
        }
        public Task<List<Product>> GetProducts()
        {
            return Task.FromResult(products);
        }
        public Task<Product> GetProduct(int id)
        {
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return Task.FromResult(products.Where(x => x.Id == id).SingleOrDefault());
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }
        public Task<bool> AddProduct(Product product)
        {
            products.Add(product);
            return Task.FromResult(true);
        }
        public Task<bool> DeleteProduct(int id)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            products.Remove(products.Where(x => x.Id == id).SingleOrDefault());
#pragma warning restore CS8604 // Possible null reference argument.
            return Task.FromResult(true);
        }
    }
}
