using Microsoft.AspNetCore.Mvc;
using pmd_be.Dto;
using pmd_be.Models;
using pmd_be.Services;

namespace pmd_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<List<ProductViewDto>>> GetProducts()
        {
            var resp =  await _productService.GetAll();
            return Ok(resp);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewDto>> GetProduct(Guid id)
        {
            var product = await _productService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // GET: api/Products/5/10
        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<ActionResult<PagedResponseDto<ProductViewDto>>> GetProductsPaged(int pageNumber=1, int pageSize=10)
        {
            if (pageSize <= 0)
                return BadRequest($"Page size must be greater than 0.");
            if (pageNumber < 0)
                return BadRequest($"Page number must be greater than 0.");
            var resp = await _productService.GetProductsPaged(pageNumber-1, pageSize);

            return Ok(resp);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(ProductCreateDto product)
        {
            var resp = await _productService.AddProduct(product);
            if (resp == null) 
            {
                return BadRequest(resp);
            }
            return CreatedAtAction("GetProduct", new { id = resp.Id }, resp);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var resp = await _productService.DeleteProduct(id);

            if (!resp)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/Products/ByCategory
        [HttpGet("ByCategory")]
        public async Task<ActionResult<IEnumerable<ProductByCategoryDto>>> GetProductsByCategory()
        {
            var product = await _productService.GetProductsByCategory();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // GET: api/Products/ByAddDate
        [HttpGet("ByAddDate")]
        public async Task<ActionResult<IEnumerable<KeyValuePair<string, int>>>> GetProductsByAddDate()
        {
            var product = await _productService.GetProductsByAddDate();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
