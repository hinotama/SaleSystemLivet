using SaleSystemData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystemAPI.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> AddOrder(Order order);

        Task<List<Order>> ListOrder(int userId);
    }
}
