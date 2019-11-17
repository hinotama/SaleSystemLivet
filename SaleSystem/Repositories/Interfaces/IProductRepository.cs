using SaleSystemData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystemAPI.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<int> AddProduct(Product product);

        Task<int> EditProduct(Product product);

        Task<int> DeleteProduct(int? productId);

        Task<Product> GetProduct(int? productId);

        Task<List<Product>> GetProducts();
        
        Task<List<Product>> GetProducts(int pageSize, int currentPage);
    }
}
