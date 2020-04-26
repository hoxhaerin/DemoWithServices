using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Core.Services.Orders
{
    public interface IOrderService
    {
        /// <summary>
        /// Gets a list of products.
        /// </summary>
        /// <param name="email">Customer email.</param>
        /// <param name="pageIndex">Current page.</param>
        /// <param name="pageSize">Page size.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns></returns>
        Task<IList<OrderModel>> GetListAsync(
            string email = "",
            int pageIndex = 0, int pageSize = 10,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates an order.
        /// </summary>
        /// <param name="request">Request from api.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns></returns>
        Task CreateOrderAsync(CreateOrderRequest request, CancellationToken cancellationToken = default);
    }
}