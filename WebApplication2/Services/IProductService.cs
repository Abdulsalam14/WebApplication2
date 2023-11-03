using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Entities;

namespace WebApplication2.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);

        Task<Product> GetProductByIdAsync(int id);
    }
}
