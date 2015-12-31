using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace MatrixContent.Framework
{
    /// <summary>
    /// Initialize database model mapping
    /// </summary>
    public interface IDatabaseModelInitializer
    {
        /// <summary>
        /// Initializes the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        void Initialize(ModelBuilder builder);
    }
}
