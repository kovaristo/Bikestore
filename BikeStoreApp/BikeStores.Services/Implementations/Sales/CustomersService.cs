using BikeStores.Contracts;
using BikeStores.Contracts.Sales.Customers;
using BikeStores.Domain.Entities.Sales;
using BikeStores.Domain.Exceptions.Sales;
using BikeStores.Domain.Repositories;
using BikeStores.Services.Abstractions.Sales;
using Mapster;

namespace BikeStores.Services.Implementations.Sales
{
    public class CustomersService : BaseService, ICustomersService
    {
        public CustomersService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }

        public async Task<int> CreateCustomerAsync(CustomerForCreateOrUpdateDTO customer, CancellationToken cancellationToken)
        {
            var customerEntity = customer.Adapt<Customer>();
            await RepositoryManager.CustomersRepository.CreateAsync(customerEntity, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
            return customerEntity.Id;
        }

        public async Task DeleteCustomerAsync(int customerId, CancellationToken cancellationToken)
        {
            var customerFound = await RepositoryManager.CustomersRepository.GetByIdAsync(customerId, cancellationToken);
            if (customerFound == null)
                throw new CustomerNotFoundException(customerId);

            await RepositoryManager.CustomersRepository.DeleteAsync(customerFound, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task<CustomerDTO> GetByIdAsync(int customerId, CancellationToken cancellationToken)
        {
            var customerFound = await RepositoryManager.CustomersRepository.GetByIdAsync(customerId, cancellationToken);
            if (customerFound == null)
                throw new CustomerNotFoundException(customerId);

            return customerFound.Adapt<CustomerDTO>();
        }

        public async Task<PagingResponse<CustomerDTO>> GetCustomersPageAsync(CustomerFilterRequest customerPageRequest, PagingRequest<CustomerDTO> pagingRequest, CancellationToken cancellationToken)
        {
            var currentPage = await RepositoryManager.CustomersRepository.GetByNameAndLocationAsync(customerPageRequest.Firstname, customerPageRequest.Lastname, customerPageRequest.Street, customerPageRequest.City, pagingRequest.OrderField, pagingRequest.Ascending, pagingRequest.StartIndex(), pagingRequest.PageSize, cancellationToken);
            return new PagingResponse<CustomerDTO>(currentPage.Data.Adapt<IEnumerable<CustomerDTO>>().ToArray(), currentPage.Total, pagingRequest);
        }

        public async Task UpdateCustomerAsync(int customerId, CustomerForCreateOrUpdateDTO customer, CancellationToken cancellationToken)
        {
            var customerFound = await RepositoryManager.CustomersRepository.GetByIdAsync(customerId, cancellationToken);
            if (customerFound == null)
                throw new CustomerNotFoundException(customerId);

            customer.Adapt(customerFound);

            await RepositoryManager.CustomersRepository.UpdateAsync(customerFound, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}
