using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Contract;
using ProductApi.Data;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IConfiguration _config;
    private readonly IProductService _productService;

    public ProductController(ILogger<ProductController> logger,
        IConfiguration configuration, IProductService productService)
    {
        _logger = logger;
        _config = configuration;
        _productService = productService;
    }

    // GET: api/products
    /// <summary>
    /// Get List of Products
    /// </summary>
    /// <returns>Product List</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var res =  await _productService.GetProducts();
        return Ok(res);
    }

    // GET: api/products/{id}
    /// <summary>
    /// Return Product detail by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Product</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var res = await _productService.GetProduct(id);
        return Ok(res);
    }

    // POST: api/products
    /// <summary>
    /// Enter detail of Product
    /// </summary>
    /// <param name="product"></param>
    /// <returns>Product</returns>
    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
        var res =  await _productService.PostProduct(product);
        return Ok(res);
    }

    // PUT: api/products/{id}
    /// <summary>
    /// Update product detail by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="product"></param>
    /// <returns>Id</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<int>> PutProduct(int id, Product product)
    {
        var res = await _productService.PutProduct(id, product);
        return Ok(res);
    }

    // DELETE: api/products/{id}
    /// <summary>
    /// Delete the product detail by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Id</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> DeleteProduct(int id)
    {
        var res = await _productService.DeleteProduct(id);
        return Ok(res);
    }
}
