using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductAPI.DTOs;
using VShop.ProductAPI.Services;

namespace VShop.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsServices _productsService;

        public ProductsController(IProductsServices productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var productDTO = await _productsService.GetProducts();

            if (productDTO == null)
            {
                return NotFound("Products not found");
            }

            return Ok(productDTO);
        }

        [HttpGet("{id:int}", Name = "GetProducts")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var productsDTO = await _productsService.GetProductById(id);

            if (productsDTO == null)
            {
                return NotFound("Product not found");
            }

            return Ok(productsDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null)
                return BadRequest("Data Invalid");

            await _productsService.AddProduct(productDTO);

            return new CreatedAtRouteResult("GetProducts", new { id = productDTO.ProductId }, productDTO);
        }

        [HttpPut("id:int")]
        public async Task<ActionResult> Put (int id, [FromBody] ProductDTO productDTO)
        {
            if(id != productDTO.ProductId)
            {
                return BadRequest("Data Invalid");
            }

            if(productDTO == null)
                return BadRequest("Data Invalid");

            await _productsService.UpdateProduct(productDTO);

            return Ok(productDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var productDTO = await _productsService.GetProductById(id);

            if(productDTO == null)
            {
                return NotFound("Product Not Found");
            }
            await _productsService.RemoveProduct(id);

            return Ok(productDTO);
        } 

    }
}
