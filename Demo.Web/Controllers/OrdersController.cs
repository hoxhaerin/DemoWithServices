using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Services.Orders;
using Demo.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Web.Controllers
{
    /// <summary>
    /// Orders endpoint.
    /// </summary>
    [Route("/api/orders")]
    [Produces("application/json")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Ctor.
        /// </summary>
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all existing orders.
        /// </summary>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns>List of products.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IList<OrderModel>), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> ListAsync(string email = "", CancellationToken cancellationToken = default)
        {
            try
            {
                var resource = await _orderService.GetListAsync(email, cancellationToken: cancellationToken);
                return Ok(resource);
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorResource(e.Message));
            }
        }

        /// <summary>
        /// Saves a new order.
        /// </summary>
        /// <param name="resource">Order data.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] CreateOrderRequest resource, CancellationToken cancellationToken = default)
        {
            try
            {
                await _orderService.CreateOrderAsync(resource, cancellationToken);
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorResource(e.Message));
            }

            return Ok();
        }

    }
}