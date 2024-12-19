using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Campo Nome obrigatório!")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Campo Price obrigatório!")]
        public decimal Price { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "Campo Stock obrigatório!")]
        [Range(1,9999)]
        public long Stock { get; set; }

        [MaxLength(250)]
        [DisplayName("Product Image")]
        public string? ImagemUrl { get; set; }
        public string? CategoryName { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
