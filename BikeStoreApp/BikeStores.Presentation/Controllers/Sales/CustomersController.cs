using BikeStores.Contracts;
using BikeStores.Contracts.Sales.Customers;
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
    public class CustomersController : BaseServiceController
    {
        public CustomersController(ILogger<CustomersController> logger, IServiceManager serviceManager) : base(logger, serviceManager)
        {
        }

        /// <summary>
        /// Get customers with filtering and paging
        /// </summary>
        /// <param name="customerFilterRequest">Customer data to filter</param>
        /// <param name="pagingRequest">Paging parameters</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetCustomers")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(PagingResponse<CustomerDTO>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetCustomersAsync([FromQuery] CustomerFilterRequest customerFilterRequest, [FromQuery] PagingRequest<CustomerDTO> pagingRequest, CancellationToken cancellationToken)
        {
            var customerDTOs = await ServiceManager.CustomersService.GetCustomersPageAsync(customerFilterRequest, pagingRequest, cancellationToken);
            return Ok(customerDTOs);
        }

        /// <summary>
        /// Get customer with selected id
        /// </summary>
        /// <param name="customerId">Customer id</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{customerId:int}", Name = "GetCustomerById")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(CustomerDTO))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetCustomerById(int customerId, CancellationToken cancellationToken)
        {
            var customerDTO = await ServiceManager.CustomersService.GetByIdAsync(customerId, cancellationToken);
            return Ok(customerDTO);
        }

        /// <summary>
        /// Creates customer
        /// </summary>
        /// <param name="customerCreateRequest">Customer data to create</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateCustomer")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CustomerForCreateOrUpdateDTO customerCreateRequest, CancellationToken cancellationToken)
        {
            int customerId = await ServiceManager.CustomersService.CreateCustomerAsync(customerCreateRequest, cancellationToken);
            return CreatedAtRoute("GetCustomerById", new { customerId = customerId }, value: customerCreateRequest);
        }

        /// <summary>
        /// Updates selected customer
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="storeUpdateRequest">Customer data to update</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{customerId:int}", Name = "UpdateCustomer")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> UpdateCustomerAsync([FromRoute] int customerId, [FromBody] CustomerForCreateOrUpdateDTO customerUpdateRequest, CancellationToken cancellationToken)
        {
            await ServiceManager.CustomersService.UpdateCustomerAsync(customerId, customerUpdateRequest, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Deletes selected customer
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{customerId:int}", Name = "DeleteCustomer")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> DeleteCustomerAsync([FromRoute] int customerId, CancellationToken cancellationToken)
        {
            await ServiceManager.CustomersService.DeleteCustomerAsync(customerId, cancellationToken);
            return Ok();
        }
    }
}
