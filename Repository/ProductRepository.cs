using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Repository.Contract;

namespace ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<int> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            
            ArgumentNullException.ThrowIfNull(product);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            return product ?? new Product();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var result = await _context.Products.ToListAsync();
            return result.ToList();
        }

        public async Task<Product> PostProduct(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<int> PutProduct(int id, Product product)
        {
            ArgumentNullException.ThrowIfNull(product);

            if (id != product.Id)
            {
                throw new ArgumentException($"Product id is not valid : {id}");
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(e => e.Id == id))
                {
                    throw new ArgumentException($"Product not found in database : {product}");
                }
                else
                {
                    throw new Exception("Technical Error");
                }
            }

            return id;
        }
    }
}
