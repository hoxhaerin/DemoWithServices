using System.Security.Claims;
using System.Threading.Tasks;
using Demo.Core.Domain.Customers;

namespace Demo.Core.Services.Authentication
{
    /// <summary>
    /// Base service interface to handle authentication.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Authenticate an entity to the application and generate an identification token.
        /// </summary>
        /// <param name="customer">The entity to authenticate.</param>
        /// <param name="claims">Optional claims to add to this authentication method. By default the username will be added.</param>
        /// <returns>Returns a value to identify the authenticated entity.</returns>
        string AuthenticateAsync(Customer customer, params Claim[] claims);

        /// <summary>
        /// Get authenticated customer.
        /// </summary>
        Task<Customer> GetAuthenticatedCustomerAsync();
    }
}