using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Demo.Core.Data;
using Demo.Core.Domain.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Demo.Services.Authentication
{
    /// <summary>
    /// Authentication service that uses JWT Tokens.
    /// </summary>
    public class TokenAuthenticationService : IAuthenticationService
    {
        private readonly string _encryptionKey;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDbContext _context;
        private Customer _cachedCustomer;

        public TokenAuthenticationService(IHttpContextAccessor httpContextAccessor, IDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _encryptionKey = "2974A65248D44C56917B2A49B8624E52";
        }

        /// <summary>
        /// Authenticate an entity to the application and generate an identification token.
        /// </summary>
        /// <param name="customer">The entity to authenticate.</param>
        /// <param name="claims">Optional claims to add to this authentication method. By default the username will be added.</param>
        /// <returns>Returns a JWT Token to identify the authenticated entity.</returns>
        public string AuthenticateAsync(Customer customer, params Claim[] claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_encryptionKey);

            // lets create a claims list here
            var tokenClaims = new List<Claim>();
            // add the username claim
            tokenClaims.Add(new Claim(ClaimTypes.Name, customer.Username));
            // add the other claims
            tokenClaims.AddRange(claims);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(tokenClaims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }


        public async Task<Customer> GetAuthenticatedCustomerAsync()
        {
            if (_cachedCustomer != null)
                return _cachedCustomer;

            if (_httpContextAccessor.HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var claims = identity.Claims;

                var usernameClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

                if (usernameClaim == null)
                    return null;

                if (string.IsNullOrWhiteSpace(usernameClaim.Value))
                    return null;

                // assign if something
                _cachedCustomer = await _context.TableReadonly<Customer>()
                    .FirstOrDefaultAsync(c => c.Username == usernameClaim.Value);
            }

            return _cachedCustomer;
        }
    }
}