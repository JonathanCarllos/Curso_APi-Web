using AutoMapper;
using VShop.ProductAPI.DTOs;
using VShop.ProductAPI.Models;
using VShop.ProductAPI.Repositories;

namespace VShop.ProductAPI.Services
{
    public class ProductServices : IProductsServices
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductServices(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var productsEntity = await _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(productsEntity);
        }

        public async Task AddProduct(ProductDTO productDTO)
        {
            var productsEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.Create(productsEntity);
            productDTO.ProductId = productsEntity.ProductId;
        }

        public async Task UpdateProduct(ProductDTO productDTO)
        {
            var produtcEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.Update(produtcEntity);
        }
        public async Task RemoveProduct(int id)
        {
            var productEntity = await _productRepository.GetById(id);
            await _productRepository.Delete(productEntity.ProductId);
        }
    }
}
