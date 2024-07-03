using BikeStores.Contracts.Sales.Customers;
using BikeStores.Contracts;
using BikeStores.Contracts.Sales.Staffs;
using BikeStores.Domain.Response;
using BikeStores.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using BikeStores.Domain.Entities.Sales;

namespace BikeStores.Presentation.Controllers.Sales
{
    [ApiController]
    [Route("[controller]")]
    public class StaffsController : BaseServiceController
    {
        public StaffsController(ILogger<StaffsController> logger, IServiceManager serviceManager) : base(logger, serviceManager)
        {
        }

        /// <summary>
        /// Get staffs with filtering and paging
        /// </summary>
        /// <param name="staffFilterRequest">Staff data to filter</param>
        /// <param name="pagingRequest">Paging parameters</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetStaffs")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(PagingResponse<CustomerDTO>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetStaffsAsync([FromQuery] StaffFilterRequest staffFilterRequest, [FromQuery] PagingRequest<StaffDTO> pagingRequest, CancellationToken cancellationToken)
        {
            var staffDTOs = await ServiceManager.StaffsService.GetStaffsPageAsync(staffFilterRequest, pagingRequest, cancellationToken);
            return Ok(staffDTOs);
        }

        /// <summary>
        /// Get staff with selected id
        /// </summary>
        /// <param name="staffId">Staff id</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{staffId:int}", Name = "GetStaffById")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(StaffDTO))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetStaffById(int staffId, CancellationToken cancellationToken)
        {
            var staffDTO = await ServiceManager.StaffsService.GetByIdAsync(staffId, cancellationToken);
            return Ok(staffDTO);
        }

        /// <summary>
        /// Creates staff
        /// </summary>
        /// <param name="staffCreateRequest">Staff data to create</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateStaff")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> CreateStaffAsync([FromBody] StaffForCreateOrUpdateDTO staffCreateRequest, CancellationToken cancellationToken)
        {
            int staffId = await ServiceManager.StaffsService.CreateStaffAsync(staffCreateRequest, cancellationToken);
            return CreatedAtRoute("GetStaffById", new { staffId = staffId }, value: staffCreateRequest);
        }

        /// <summary>
        /// Updates selected staff
        /// </summary>
        /// <param name="staffId">Staff identifier</param>
        /// <param name="staffUpdateRequest">Staff data to update</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{staffId:int}", Name = "UpdateStaff")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> UpdateStaffAsync([FromRoute] int staffId, [FromBody] StaffForCreateOrUpdateDTO staffUpdateRequest, CancellationToken cancellationToken)
        {
            await ServiceManager.StaffsService.UpdateStaffAsync(staffId, staffUpdateRequest, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Deletes selected staff
        /// </summary>
        /// <param name="staffId">Staff identifier</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{staffId:int}", Name = "DeleteStaff")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> DeleteStaffAsync([FromRoute] int staffId, CancellationToken cancellationToken)
        {
            await ServiceManager.StaffsService.DeleteStaffAsync(staffId, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Get subordinates for selected managerId
        /// </summary>
        /// <param name="staffId">Manager id</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{staffId:int}/Subordinates", Name = "GetSubordinatesByStaffId")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<StaffDTO>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetSubordinatesByStaffId(int staffId, CancellationToken cancellationToken)
        {
            var staffDTOs = await ServiceManager.StaffsService.GetSubordinatesAsync(staffId, cancellationToken);
            return Ok(staffDTOs);
        }
    }
}
