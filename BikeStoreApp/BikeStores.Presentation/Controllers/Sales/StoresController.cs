using BikeStores.Contracts;
using BikeStores.Contracts.Sales.Staffs;
using BikeStores.Contracts.Sales.Stores;
using BikeStores.Domain.Entities.Sales;
using BikeStores.Domain.Response;
using BikeStores.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace BikeStores.Presentation.Controllers.Sales
{
    [ApiController]
    [Route("[controller]")]
    public class StoresController : BaseServiceController
    {
        public StoresController(ILogger<StoresController> logger, IServiceManager serviceManager) : base(logger, serviceManager)
        {
        }

        /// <summary>
        /// Get stores with filtering and paging
        /// </summary>
        /// <param name="storeFilterRequest">Store data to filter</param>
        /// <param name="pagingRequest">Paging parameters</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetStores")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(PagingResponse<StoreDTO>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetStoresAsync([FromQuery] StoreFilterRequest storeFilterRequest, [FromQuery] PagingRequest<StoreDTO> pagingRequest, CancellationToken cancellationToken)
        {
            var storeDTOs = await ServiceManager.StoresService.GetStoresPageAsync(storeFilterRequest, pagingRequest, cancellationToken);
            return Ok(storeDTOs);
        }

        /// <summary>
        /// Get store with selected id
        /// </summary>
        /// <param name="storeId">Store id</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{storeId:int}", Name = "GetStoreById")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(StoreDTO))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetStoreById(int storeId, CancellationToken cancellationToken)
        {
            var storeDTO = await ServiceManager.StoresService.GetByIdAsync(storeId, cancellationToken);
            return Ok(storeDTO);
        }

        /// <summary>
        /// Creates store
        /// </summary>
        /// <param name="storeCreateRequest">Store data to create</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateStore")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> CreateStoreAsync([FromBody] StoreForCreateOrUpdateDTO storeCreateRequest, CancellationToken cancellationToken)
        {
            int storeId = await ServiceManager.StoresService.CreateStoreAsync(storeCreateRequest, cancellationToken);
            return CreatedAtRoute("GetStoreById", new { storeId = storeId }, value: storeCreateRequest);
        }

        /// <summary>
        /// Updates selected store
        /// </summary>
        /// <param name="storeId">Store identifier</param>
        /// <param name="storeUpdateRequest">Brand data to update</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{storeId:int}", Name = "UpdateStore")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> UpdateStoreAsync([FromRoute] int storeId, [FromBody] StoreForCreateOrUpdateDTO storeUpdateRequest, CancellationToken cancellationToken)
        {
            await ServiceManager.StoresService.UpdateStoreAsync(storeId, storeUpdateRequest, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Deletes selected store
        /// </summary>
        /// <param name="storeId">Store identifier</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{storeId:int}", Name = "DeleteStore")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> DeleteStoreAsync([FromRoute] int storeId, CancellationToken cancellationToken)
        {
            await ServiceManager.StoresService.DeleteStoreAsync(storeId, cancellationToken);
            return Ok();
        }

        [HttpGet("{storeId:int}/Staffs", Name = "GetStaffByStore")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<StaffDTO>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetStaffByStore(int storeId, CancellationToken cancellationToken)
        {
            var staffDTOs = await ServiceManager.StaffsService.GetStaffByStore(storeId, cancellationToken);
            return Ok(staffDTOs);
        }
    }
}
