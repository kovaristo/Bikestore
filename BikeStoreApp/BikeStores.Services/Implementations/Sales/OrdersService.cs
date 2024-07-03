using BikeStores.Contracts;
using BikeStores.Contracts.Production.Categories;
using BikeStores.Contracts.Sales.Orders;
using BikeStores.Domain.Entities.Production;
using BikeStores.Domain.Entities.Sales;
using BikeStores.Domain.Enums;
using BikeStores.Domain.Exceptions.Production;
using BikeStores.Domain.Exceptions.Sales;
using BikeStores.Domain.Repositories;
using BikeStores.Services.Abstractions.Sales;
using Mapster;

namespace BikeStores.Services.Implementations.Sales
{
    public class OrdersService : BaseService, IOrdersService
    {
        public OrdersService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }

        public async Task<int> CreateOrderAsync(OrderForCreateDTO order, CancellationToken cancellationToken)
        {
            var orderEntity = order.Adapt<Order>();

            if (RepositoryManager.StaffsRepository.GetByIdAsync(order.StaffId, cancellationToken).Result == null)
                throw new StaffNotFoundException(order.StaffId);
            if (RepositoryManager.StoresRepository.GetByIdAsync(order.StoreId, cancellationToken).Result == null)
                throw new StoreNotFoundException(order.StoreId);
            if (order.CustomerId.HasValue && RepositoryManager.CustomersRepository.GetByIdAsync(order.CustomerId.Value, cancellationToken).Result == null)
                throw new CustomerNotFoundException(order.CustomerId.Value);

            await RepositoryManager.OrdersRepository.CreateAsync(orderEntity, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
            return orderEntity.Id;
        }

        public async Task DeleteOrderAsync(int orderId, CancellationToken cancellationToken)
        {
            var orderFound = await RepositoryManager.OrdersRepository.GetByIdAsync(orderId, cancellationToken);
            if (orderFound == null)
                throw new OrderNotFoundException(orderId);

            await RepositoryManager.OrdersRepository.DeleteAsync(orderFound, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task<OrderDTO> GetByIdAsync(int orderId, CancellationToken cancellationToken)
        {
            var orderFound = await RepositoryManager.OrdersRepository.GetByIdAsync(orderId, cancellationToken);
            if (orderFound == null)
                throw new OrderNotFoundException(orderId);

            return orderFound.Adapt<OrderDTO>();
        }

        public async Task<PagingResponse<OrderDTO>> GetOrdersPageAsync(OrderFilterRequest orderPageRequest, PagingRequest<OrderDTO> pagingRequest, CancellationToken cancellationToken)
        {
            OrderStatusEnum orderStatusValue = orderPageRequest.OrderStatus.Adapt<OrderStatusEnum>();
            var currentPage = await RepositoryManager.OrdersRepository.GetByCustomerAndOrderParams(orderPageRequest.CustomerId, orderPageRequest.StoreId, orderStatusValue, orderPageRequest.OrderDate, pagingRequest.OrderField, pagingRequest.Ascending, pagingRequest.StartIndex(), pagingRequest.PageSize, cancellationToken);
            return new PagingResponse<OrderDTO>(currentPage.Data.Adapt<IEnumerable<OrderDTO>>().ToArray(), currentPage.Total, pagingRequest);
        }

        public async Task UpdateOrderAsync(int orderId, OrderForUpdateDTO order, CancellationToken cancellationToken)
        {
            var orderFound = await RepositoryManager.OrdersRepository.GetByIdAsync(orderId, cancellationToken);
            if (orderFound == null)
                throw new OrderNotFoundException(orderId);

            order.Adapt(orderFound);

            await RepositoryManager.OrdersRepository.UpdateAsync(orderFound, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}
