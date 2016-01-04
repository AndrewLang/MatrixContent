using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixContent.Framework
{
    /// <summary>
    /// Repository perform CRUD  operations
    /// </summary>
    /// <remarks>
    /// This repository used with Entity Framework
    /// </remarks>
    public interface IRepository:IDisposable
    {
        /// <summary>
        /// Gets queryable of <typeparamref name="TEntity"/>
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class, new();

        /// <summary>
        /// Adds <typeparamref name="TEntity"/> 
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        void Add<TEntity>(TEntity entity) where TEntity : class, new();
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entities">The entities.</param>
        void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, new();
        /// <summary>
        /// Deletes <typeparamref name="TEntity"/> 
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        void Delete<TEntity>(TEntity entity) where TEntity : class, new();

        /// <summary>
        /// Updates the specified entity
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="toUpdate">The entity to update.</param>
        /// <param name="update">The update.</param>
        void Update<TEntity>(TEntity toUpdate,Action<TEntity> update) where TEntity : class, new();

        /// <summary>
        /// Saves the changes.
        /// </summary>
        int SaveChanges();
    }
}
