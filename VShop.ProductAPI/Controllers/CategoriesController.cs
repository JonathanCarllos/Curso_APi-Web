using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductAPI.DTOs;
using VShop.ProductAPI.Services;

namespace VShop.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categoriesDTO = await _categoryServices.GetCategories();

            if (categoriesDTO is null)
                return NotFound("Categories not found");

            return Ok(categoriesDTO);
        }

        [HttpGet("Products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
        {
            var categoriesDTO = await _categoryServices.GetCategoriesProducts();

            if (categoriesDTO == null)
                return NotFound("Categories not found");

            return Ok(categoriesDTO);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var categoryDTO = await _categoryServices.GetCategoryById(id);

            if (categoryDTO == null)
            {
                return NotFound("Category not found");
            }

            return Ok(categoryDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
                return BadRequest("Invalid Data");

            await _categoryServices.AddCategory(categoryDTO);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.CategoryId }, categoryDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.CategoryId)
                return BadRequest();

            if (categoryDTO == null)
                return BadRequest();

            await _categoryServices.UpdateCategory(categoryDTO);

            return Ok(categoryDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var categoryDTO = await _categoryServices.GetCategoryById(id);

            if(categoryDTO == null)
            {
                return NotFound("Category not found");
            }

            await _categoryServices.RemoveCategory(id);

            return Ok(categoryDTO);
        }
    }
}
