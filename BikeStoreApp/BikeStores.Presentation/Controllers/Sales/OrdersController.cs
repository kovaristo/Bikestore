using BikeStores.Contracts;
using BikeStores.Contracts.Production.Brands;
using BikeStores.Contracts.Sales.Orders;
using BikeStores.Domain.Response;
using BikeStores.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace BikeStores.Presentation.Controllers.Sales
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : BaseServiceController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="serviceManager"></param>
        public OrdersController(ILogger<OrdersController> logger, IServiceManager serviceManager) : base(logger, serviceManager)
        {
        }

        /// <summary>
        /// Get orders with filtering and paging
        /// </summary>
        /// <param name="orderFilterRequest">Order data to filter</param>
        /// <param name="pagingRequest">Paging parameters</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetOrders")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(PagingResponse<OrderDTO>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetOrdersAsync([FromQuery] OrderFilterRequest orderFilterRequest, [FromQuery] PagingRequest<OrderDTO> pagingRequest, CancellationToken cancellationToken)
        {
            var orderDTOs = await ServiceManager.OrdersService.GetOrdersPageAsync(orderFilterRequest, pagingRequest, cancellationToken);
            return Ok(orderDTOs);
        }

        /// <summary>
        /// Get order with selected id
        /// </summary>
        /// <param name="orderId">Order id</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{orderId:int}", Name = "GetOrderById")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(OrderDTO))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetOrderById(int orderId, CancellationToken cancellationToken)
        {
            var orderDTO = await ServiceManager.OrdersService.GetByIdAsync(orderId, cancellationToken);
            return Ok(orderDTO);
        }

        /// <summary>
        /// Creates order
        /// </summary>
        /// <param name="orderCreateRequest">Order data to create</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateOrder")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> CreateOrderAsync([FromBody] OrderForCreateDTO orderCreateRequest, CancellationToken cancellationToken)
        {
            int orderId = await ServiceManager.OrdersService.CreateOrderAsync(orderCreateRequest, cancellationToken);
            var createdOrder = await ServiceManager.OrdersService.GetByIdAsync(orderId, cancellationToken);
            return CreatedAtRoute("GetOrderById", new { orderId = orderId }, value: createdOrder);
        }

        /// <summary>
        /// Updates selected order
        /// </summary>
        /// <param name="orderId">Order identifier</param>
        /// <param name="orderUpdateRequest">Order data to update</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{orderId:int}", Name = "UpdateOrder")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> UpdateOrderAsync([FromRoute] int orderId, [FromBody] OrderForUpdateDTO orderUpdateRequest, CancellationToken cancellationToken)
        {
            await ServiceManager.OrdersService.UpdateOrderAsync(orderId, orderUpdateRequest, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Deletes selected order
        /// </summary>
        /// <param name="orderId">Order identifier</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{orderId:int}", Name = "DeleteOrder")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> DeleteOrderAsync([FromRoute] int orderId, CancellationToken cancellationToken)
        {
            await ServiceManager.OrdersService.DeleteOrderAsync(orderId, cancellationToken);
            return Ok();
        }
    }
}
