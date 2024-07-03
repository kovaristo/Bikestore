using BikeStores.Contracts.Sales.Customers;
using BikeStores.Contracts;
using BikeStores.Contracts.Sales.Staffs;

namespace BikeStores.Services.Abstractions.Sales
{
    public interface IStaffsService
    {
        Task<StaffDTO> GetByIdAsync(int orderId, CancellationToken cancellationToken);

        Task<IEnumerable<StaffDTO>> GetStaffByStore(int storeId, CancellationToken cancellationToken);
        Task<IEnumerable<StaffDTO>> GetSubordinatesAsync(int managerId, CancellationToken cancellationToken);
        Task<PagingResponse<StaffDTO>> GetStaffsPageAsync(StaffFilterRequest staffPageRequest, PagingRequest<StaffDTO> pagingRequest, CancellationToken cancellationToken);
        Task<int> CreateStaffAsync(StaffForCreateOrUpdateDTO staffCreateRequest, CancellationToken cancellationToken);
        Task UpdateStaffAsync(int staffId, StaffForCreateOrUpdateDTO staff, CancellationToken cancellationToken);
        Task DeleteStaffAsync(int staffId, CancellationToken cancellationToken);
    }
}
