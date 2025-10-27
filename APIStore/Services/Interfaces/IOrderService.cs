using APIStore.DTOs;
using APIStore.DTOs.Orders;

namespace APIStore.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDTO>> GetAllOrder();
        Task<OrderDetailDTO?> GetOrderById(int id);
    }
}
