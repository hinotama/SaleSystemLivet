using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaleSystemAPI.Repositories.Interfaces;
using SaleSystemAPI.Services.Interfaces;
using SaleSystemData.Models;

namespace SaleSystemAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<int> AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public Task<int> DeleteProduct(int? productId)
        {
            return _productRepository.DeleteProduct(productId);
        }

        public Task<int> EditProduct(Product product)
        {
            return _productRepository.EditProduct(product);
        }

        public Task<Product> GetProduct(int? productId)
        {
            return _productRepository.GetProduct(productId);
        }

        public Task<List<Product>> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public Task<List<Product>> GetProducts(int pageSize, int currentPage)
        {
            return _productRepository.GetProducts(pageSize, currentPage);
        }
    }
}
