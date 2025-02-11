using Microsoft.AspNetCore.Mvc;

namespace ProductApi.Contract
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProduct(int id);

        Task<Product> PostProduct(Product product);

        Task<int> PutProduct(int id, Product product);

        Task<int> DeleteProduct(int id);

    }
}
