using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Demo.Core.Data;
using Demo.Core.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Demo.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _products;
        private readonly IConfigurationProvider _configurationProvider;

        public ProductService(IRepository<Product> products, IConfigurationProvider configurationProvider)
        {
            _products = products;
            _configurationProvider = configurationProvider;
        }

        /// <summary>
        /// Gets a list of products.
        /// </summary>
        /// <param name="pageIndex">Current page.</param>
        /// <param name="pageSize">Page size.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns></returns>
        public async Task<IList<ProductModel>> GetListAsync(int pageIndex = 0, int pageSize = 10, CancellationToken cancellationToken = default(CancellationToken))
        {
            var list = await _products.TableNoTracking
                .ProjectTo<ProductModel>(_configurationProvider)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return list;
        }

       /// <summary>
       /// Creates a product. feature
       /// </summary>
       /// <param name="request"></param>
       /// <param name="cancellationToken"></param>
       /// <returns></returns>
        public async Task CreateProductAsync(CreateProductRequest request, CancellationToken cancellationToken = default)
        {
            // create an entity
            var entity = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            await _products.InsertAsync(entity, cancellationToken);
        }

        /// <summary>
        /// Updates a product.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <param name="request">Request from the api.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        public async Task UpdateProductAsync(Guid id, UpdateProductRequest request, CancellationToken cancellationToken = default)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id), "Id cannot be null.");

            // create an entity
            var entity = new Product
            {
                Id = id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            await _products.UpdateAsync(entity, cancellationToken);
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="productId">Id of the product to delete.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns></returns>
        public async Task DeleteProductAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            var entity = await _products.Table
                .FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);

            // remove
            await _products.DeleteAsync(entity, cancellationToken);
        }
    }
}