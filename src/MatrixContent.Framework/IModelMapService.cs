using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixContent.Framework
{
    /// <summary>
    /// Data model mapping service
    /// </summary>
    public interface IModelMapService
    {
        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
