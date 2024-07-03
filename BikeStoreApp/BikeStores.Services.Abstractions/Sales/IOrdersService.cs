using BikeStores.Contracts.Sales.Customers;
using BikeStores.Contracts;
using BikeStores.Contracts.Sales.Orders;

namespace BikeStores.Services.Abstractions.Sales
{
    public interface IOrdersService
    {
        Task<OrderDTO> GetByIdAsync(int orderId, CancellationToken cancellationToken);
        Task<PagingResponse<OrderDTO>> GetOrdersPageAsync(OrderFilterRequest orderPageRequest, PagingRequest<OrderDTO> pagingRequest, CancellationToken cancellationToken);
        Task<int> CreateOrderAsync(OrderForCreateDTO order, CancellationToken cancellationToken);
        Task UpdateOrderAsync(int orderId, OrderForUpdateDTO order, CancellationToken cancellationToken);
        Task DeleteOrderAsync(int orderId, CancellationToken cancellationToken);
    }
}
