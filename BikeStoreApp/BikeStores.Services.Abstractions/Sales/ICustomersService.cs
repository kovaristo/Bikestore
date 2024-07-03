using BikeStores.Contracts;
using BikeStores.Contracts.Sales.Customers;

namespace BikeStores.Services.Abstractions.Sales
{
    public interface ICustomersService
    {
        Task<CustomerDTO> GetByIdAsync(int customerId, CancellationToken cancellationToken);
        Task<PagingResponse<CustomerDTO>> GetCustomersPageAsync(CustomerFilterRequest customerPageRequest, PagingRequest<CustomerDTO> pagingRequest, CancellationToken cancellationToken);
        Task<int> CreateCustomerAsync(CustomerForCreateOrUpdateDTO customerCreateRequest, CancellationToken cancellationToken);
        Task UpdateCustomerAsync(int customerId, CustomerForCreateOrUpdateDTO customer, CancellationToken cancellationToken);
        Task DeleteCustomerAsync(int customerId, CancellationToken cancellationToken);
    }
}
