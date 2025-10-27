using APIStore.DTOs;
using APIStore.DTOs.Orders;
using APIStore.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace APIStore.Repositories
{
    public class OrderRepository
    {
        private readonly StoreDbContext _context;

        public OrderRepository(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<OrderDTO>> GetAllOrder()
        {
            return await _context.Orders
                .Include(o => o.Customers)
                .Select(o => new OrderDTO
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    CustomerId = o.CustomerId,
                    CustomerName = o.Customers != null ? o.Customers.FullName : "",
                    CustomerEmail = o.Customers != null ? o.Customers.Email : ""
                })
                .ToListAsync();
        }
        public async Task<OrderDetailDTO?> GetOrderById(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Customers)
                .Include(o => o.OrderItems!)
                    .ThenInclude(oi => oi.Products)
                .Where(o => o.Id == id)
                .Select(o => new OrderDetailDTO
                {
                    OrderId = o.Id,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    CustomerName = o.Customers!.FullName,
                    Items = o.OrderItems!.Select(oi => new OrderItemDetailDTO
                    {
                        ProductName = oi.Products!.Name,
                        Quantity = oi.Quantity,
                        UnitPrice = oi.UnitPrice
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return order;
        }
    }
}
