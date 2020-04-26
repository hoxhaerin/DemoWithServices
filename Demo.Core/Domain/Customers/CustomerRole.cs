namespace Demo.Core.Domain.Customers
{
    /// <summary>
    /// Represents the role of the customer.
    /// </summary>
    public enum CustomerRole
    {
        /// <summary>
        /// Admin user. Has access to all the application.
        /// </summary>
        Admin = 0,

        /// <summary>
        /// Regular user. Has basic privileges.
        /// </summary>
        Regular = 1
    }
}