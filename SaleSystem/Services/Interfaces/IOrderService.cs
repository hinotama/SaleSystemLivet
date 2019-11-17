using SaleSystemData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystemAPI.Services.Interfaces
{
    public interface IOrderService
    {
        Task<int> AddOrder(Order order);

        Task<List<Order>> ListOrder(int userId);
    }
}
