using BikeStores.Contracts;
using BikeStores.Contracts.Production.Products;
using BikeStores.Domain.Response;
using BikeStores.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace BikeStores.Presentation.Controllers.Production
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : BaseServiceController
    {
        public ProductsController(ILogger<ProductsController> logger, IServiceManager serviceManager) : base(logger, serviceManager)
        {
        }

        /// <summary>
        /// Get products with filtering and paging
        /// </summary>
        /// <param name="productFilterRequest">Product data to filter</param>
        /// <param name="pagingRequest">Paging parameters</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetProducts")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(PagingResponse<ProductDTO>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetProductsAsync([FromQuery] ProductFilterRequest productFilterRequest, [FromQuery] PagingRequest<ProductDTO> pagingRequest, CancellationToken cancellationToken)
        {
            var categoryDTOs = await ServiceManager.ProductsService.GetProductsPageAsync(productFilterRequest, pagingRequest, cancellationToken);
            return Ok(categoryDTOs);
        }

        /// <summary>
        /// Get product with selected id
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{productId:int}", Name = "GetProductById")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ProductDTO))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetProductByIdAsync(int productId, CancellationToken cancellationToken)
        {
            var productDto = await ServiceManager.ProductsService.GetByIdAsync(productId, cancellationToken);
            return Ok(productDto);
        }

        /// <summary>
        /// Creates product
        /// </summary>
        /// <param name="productCreateRequest">Product data to create</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateProduct")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductForCreateOrUpdateDTO productCreateRequest, CancellationToken cancellationToken)
        {
            int productId = await ServiceManager.ProductsService.CreateProductAsync(productCreateRequest, cancellationToken);
            return CreatedAtRoute("GetProductById", new { productId = productId }, value: productCreateRequest);
        }

        /// <summary>
        /// Updates selected product
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <param name="productUpdateRequest">Product data to update</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{productId:int}", Name = "UpdateProduct")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> UpdateProductAsync([FromRoute] int productId, [FromBody] ProductForCreateOrUpdateDTO productUpdateRequest, CancellationToken cancellationToken)
        {
            await ServiceManager.ProductsService.UpdateProductAsync(productId, productUpdateRequest, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Deletes selected product
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{productId:int}", Name = "DeleteProduct")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] int productId, CancellationToken cancellationToken)
        {
            await ServiceManager.ProductsService.DeleteProductAsync(productId, cancellationToken);
            return Ok();
        }
    }
}
