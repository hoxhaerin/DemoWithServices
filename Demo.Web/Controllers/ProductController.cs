using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Core.Domain.Products;
using Demo.Core.Infrastructure;
using Demo.Core.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.Web.Controllers
{
    /// <summary>
    /// Products endpoint.
    /// </summary>
    [Route("/api/products")]
    [Produces("application/json")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Ctor.
        /// </summary>
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all existing products.
        /// </summary>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns>List of products.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IList<ProductModel>), 200)]
        public async Task<IList<ProductModel>> ListAsync(CancellationToken cancellationToken = default)
        {
            var resource = await _productService.GetListAsync(cancellationToken: cancellationToken);
            return resource;
        }

        /// <summary>
        /// Saves a new product.
        /// </summary>
        /// <param name="resource">Product data.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] CreateProductRequest resource, CancellationToken cancellationToken = default)
        {

            try
            {
                await _productService.CreateProductAsync(resource, cancellationToken);
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorResource(e.Message));
            }

            return Ok();
        }

        /// <summary>
        /// Updates an existing product according to an identifier.
        /// </summary>
        /// <param name="id">Product identifier.</param>
        /// <param name="resource">Product data.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType( 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] UpdateProductRequest resource, CancellationToken cancellationToken = default)
        {
            try
            {
                await _productService.UpdateProductAsync(id, resource, cancellationToken);
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorResource(e.Message));
            }

            return Ok();
        }

        /// <summary>
        /// Deletes a given product according to an identifier.
        /// </summary>
        /// <param name="id">Product identifier.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                await _productService.DeleteProductAsync(id, cancellationToken);
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorResource(e.Message));
            }

            return Ok();
        }
    }
}
