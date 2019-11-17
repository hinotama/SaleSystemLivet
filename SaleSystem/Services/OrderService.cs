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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<int> AddOrder(Order order)
        {
            return _orderRepository.AddOrder(order);
        }

        public Task<List<Order>> ListOrder(int userId)
        {
            return _orderRepository.ListOrder(userId);
        }
    }
}
