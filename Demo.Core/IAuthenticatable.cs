namespace Demo.Core
{
    /// <summary>
    /// Base interface for entities that support authentication.
    /// </summary>
    public interface IAuthenticatable
    {
        /// <summary>
        /// Username of the entity that is trying to authenticate.
        /// </summary>
        string Username { get; set; }
    }
}