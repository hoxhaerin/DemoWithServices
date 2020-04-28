using System;

namespace Demo.Services
{
    /// <summary>
    /// Base class for entities.
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        public Guid Id { get; set; }
    }
}