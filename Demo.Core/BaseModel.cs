using System;

namespace Demo.Core
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