﻿using System.ComponentModel.DataAnnotations;

namespace VShop.Web.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public long Stock { get; set; }
        [Required]
        public string? ImagemUrl { get; set; }
        public string? CategoryName { get; set; }

        [Display(Name = "Categories")]
        public int CategoryId { get; set; }
    }
}
