using Microsoft.AspNetCore.Mvc;
using ProductApi.Contract;
using ProductApi.Repository.Contract;

namespace ProductApi.Domain
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> DeleteProduct(int id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return await _productRepository.DeleteProduct(id);
        }

        public async Task<Product> GetProduct(int id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return await _productRepository.GetProduct(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }

        public async Task<Product> PostProduct(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);
            return await _productRepository.PostProduct(product);
        }

        public async Task<int> PutProduct(int id, Product product)
        {
            ArgumentNullException.ThrowIfNull(id);
            ArgumentNullException.ThrowIfNull(product);
            return await _productRepository.PutProduct(id, product);
        }
    }
}
