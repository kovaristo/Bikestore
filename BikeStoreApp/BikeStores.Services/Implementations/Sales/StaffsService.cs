using BikeStores.Contracts;
using BikeStores.Contracts.Production.Categories;
using BikeStores.Contracts.Sales.Staffs;
using BikeStores.Domain.Entities.Production;
using BikeStores.Domain.Entities.Sales;
using BikeStores.Domain.Exceptions.Production;
using BikeStores.Domain.Exceptions.Sales;
using BikeStores.Domain.Repositories;
using BikeStores.Services.Abstractions.Sales;
using Mapster;

namespace BikeStores.Services.Implementations.Sales
{
    public class StaffsService : BaseService, IStaffsService
    {
        public StaffsService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }

        public async Task<int> CreateStaffAsync(StaffForCreateOrUpdateDTO staff, CancellationToken cancellationToken)
        {
            var staffEntity = staff.Adapt<Staff>();
            await RepositoryManager.StaffsRepository.CreateAsync(staffEntity, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
            return staffEntity.Id;
        }

        public async Task DeleteStaffAsync(int staffId, CancellationToken cancellationToken)
        {
            var staffFound = await RepositoryManager.StaffsRepository.GetByIdAsync(staffId, cancellationToken);
            if (staffFound == null)
                throw new StaffNotFoundException(staffId);

            await RepositoryManager.StaffsRepository.DeleteAsync(staffFound, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<StaffDTO>> GetSubordinatesAsync(int managerId, CancellationToken cancellationToken)
        {
            var staffs = await RepositoryManager.StaffsRepository.GetByManagerId(managerId, cancellationToken);
            return staffs.Adapt<IEnumerable<StaffDTO>>();
        }

        public async Task<StaffDTO> GetByIdAsync(int staffId, CancellationToken cancellationToken)
        {
            var staffFound = await RepositoryManager.StaffsRepository.GetByIdAsync(staffId, cancellationToken);
            if (staffFound == null)
                throw new StaffNotFoundException(staffId); 
            
            return staffFound.Adapt<StaffDTO>();
        }

        public async Task<PagingResponse<StaffDTO>> GetStaffsPageAsync(StaffFilterRequest staffPageRequest, PagingRequest<StaffDTO> pagingRequest, CancellationToken cancellationToken)
        {
            var currentPage = await RepositoryManager.StaffsRepository.GetByStaffDataAndStoreId(
                staffPageRequest.Firstname, staffPageRequest.Lastname, staffPageRequest.Email, staffPageRequest.Phone, 
                staffPageRequest.Active, staffPageRequest.StoreId, 
                pagingRequest.OrderField, pagingRequest.Ascending, pagingRequest.StartIndex(), pagingRequest.PageSize, cancellationToken);
            return new PagingResponse<StaffDTO>(currentPage.Data.Adapt<IEnumerable<StaffDTO>>().ToArray(), currentPage.Total, pagingRequest);
        }

        public async Task UpdateStaffAsync(int staffId, StaffForCreateOrUpdateDTO staff, CancellationToken cancellationToken)
        {
            var staffFound = await RepositoryManager.StaffsRepository.GetByIdAsync(staffId, cancellationToken);
            if (staffFound == null)
                throw new StaffNotFoundException(staffId);

            staff.Adapt(staffFound);

            await RepositoryManager.StaffsRepository.UpdateAsync(staffFound, cancellationToken);
            await RepositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<StaffDTO>> GetStaffByStore(int storeId, CancellationToken cancellationToken)
        {
            var storeFound = await RepositoryManager.StoresRepository.GetByIdAsync(storeId, cancellationToken);
            if (storeFound == null)
                throw new StoreNotFoundException(storeId);

            var staffs = await RepositoryManager.StaffsRepository.GetByStoreId(storeId, cancellationToken);
            return staffs.Adapt<IEnumerable<StaffDTO>>();
        }
    }
}
