using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Entities;

namespace WebApplication2.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
