using VShop.Web.Models;

namespace VShop.Web.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProducts();
        Task<ProductViewModel> FindProductById(int id);
        Task<ProductViewModel> CreateProduct(ProductViewModel product);
        Task<ProductViewModel> UpdateProduct(ProductViewModel product);
        Task<bool> DeleteProductById(int id);
    }
}
