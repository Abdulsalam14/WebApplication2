using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Entities;

namespace WebApplication2.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;

        public EFProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            var DeleteProduct= await _dbContext.Products.FindAsync(product.Id);
            _dbContext.Remove(DeleteProduct);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            var UpdateProduct = await _dbContext.Products.FindAsync(product.Id);
            if(UpdateProduct is not null)
            {
                UpdateProduct.Name = product.Name;
                UpdateProduct.Description = product.Description;
                UpdateProduct.Price= product.Price;
                UpdateProduct.Discount= product.Discount;
                UpdateProduct.ImagePath= product.ImagePath;

                _dbContext.Update(UpdateProduct);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
