using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetProductApi.Data;
using DotNetProductApi.Models;

namespace DotNetProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(AppDbContext db, ILogger<ProductsController> logger)
        {
            _db = db;
            _logger = logger;
        }

        // GET: api/products
        // GET: api/products?categoryId=3
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] int? categoryId)
        {
            try
            {
                IQueryable<Product> query = _db.Products.Include(p => p.Category);

                if (categoryId.HasValue)
                    query = query.Where(p => p.CategoryId == categoryId.Value);

                var products = await query.ToListAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving products.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        // GET: api/products/10
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try { 
                var product = await _db.Products
                    .Include(p => p.Category)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (product == null)
                    return NotFound();

            return Ok(product);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving a product.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            try
            {
                _db.Products.Add(product);
                await _db.SaveChangesAsync();
                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new product.");    
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}

