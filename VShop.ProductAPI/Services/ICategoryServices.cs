using VShop.ProductAPI.DTOs;

namespace VShop.ProductAPI.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();
        Task<CategoryDTO> GetCategoryById(int id);
        Task AddCategory(CategoryDTO categoryDTO);
        Task UpdateCategory(CategoryDTO categoryDTO);
        Task RemoveCategory(int id);

    }
}
