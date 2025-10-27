using APIStore.DTOs;
using APIStore.DTOs.Orders;
using APIStore.Repositories;
using APIStore.Services.Interfaces;

namespace APIStore.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepository _orderRepo;

        public OrderService(OrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<List<OrderDTO>> GetAllOrder()
        {
            return await _orderRepo.GetAllOrder();
        }

        public async Task<OrderDetailDTO?> GetOrderById(int id)
        {
            return await _orderRepo.GetOrderById(id);
        }
    }
}
