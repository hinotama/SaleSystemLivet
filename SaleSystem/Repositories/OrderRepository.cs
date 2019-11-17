using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaleSystemAPI.Repositories.Interfaces;
using SaleSystemData.Models;

namespace SaleSystemAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SaleSystemDBContext _context;

        public OrderRepository(SaleSystemDBContext context)
        {
            _context = context;
        }

        public async Task<int> AddOrder(Order order)
        {
            int result = 0;
            if (_context != null)
            {
                // Add that Order.
                await _context.Order.AddAsync(order);

                // Commit the transaction.
                await _context.SaveChangesAsync();

                result = order.OrderId;
            }
            return result;
        }

        public async Task<List<Order>> ListOrder(int userId)
        {
            if (_context != null)
            {
                // Select all Products from Product table in the db.
                return await (from o in _context.Order
                              where o.UserId == userId
                              select new Order
                              {
                                  OrderId = o.OrderId,
                                  User = o.User,
                                  Product = o.Product,
                                  Quantity = o.Quantity
                              }).ToListAsync();
            }
            return null;
        }
    }
}
