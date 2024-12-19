using System.ComponentModel.DataAnnotations;
using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Campo Nome obrigatório!")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
