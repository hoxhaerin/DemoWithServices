using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Core.Services.Products
{
    public interface IProductService
    {
        /// <summary>
        /// Gets a list of products.
        /// </summary>
        /// <param name="pageIndex">Current page.</param>
        /// <param name="pageSize">Page size.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns></returns>
        Task<IList<ProductModel>> GetListAsync(int pageIndex = 0, int pageSize = 10, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a product.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task CreateProductAsync(CreateProductRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a product.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <param name="request">Request from the api.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        Task UpdateProductAsync(Guid id, UpdateProductRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="productId">Id of the product to delete.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns></returns>
        Task DeleteProductAsync(Guid productId, CancellationToken cancellationToken = default);
    }
}