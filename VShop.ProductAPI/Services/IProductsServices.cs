using VShop.ProductAPI.DTOs;

namespace VShop.ProductAPI.Services
{
    public interface IProductsServices
    {
        Task<IEnumerable<ProductDTO>> GetProducts();  
        Task<ProductDTO> GetProductById(int id);
        Task AddProduct(ProductDTO productDTO);
        Task UpdateProduct(ProductDTO productDTO);
        Task RemoveProduct(int id);
    }
}
