using DotNetProductApi.Data;
using DotNetProductApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ILogger<CategoriesController> _logger;
        public CategoriesController(AppDbContext db, ILogger<CategoriesController> logger )
        {
            _db = db;
            _logger = logger;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await _db.Categories
                    .Include(c => c.Products)   // optional: include products
                    .ToListAsync();

                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving categories.");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            try
            {
                var category = await _db.Categories
                    .Include(c => c.Products)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (category == null)
                    return NotFound();

                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving category with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/categories
        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            try
            {
                _db.Categories.Add(category);
                await _db.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new category.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

