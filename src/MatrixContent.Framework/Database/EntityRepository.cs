using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace MatrixContent.Framework
{
    /// <summary>
    /// Implement <see cref="IRepository"/> with EF code first
    /// </summary>
    public class EntityRepository:IRepository
    {
        #region ... Variables  ...
        DbContext mContext;
        #endregion ...Variables...

        #region ... Events     ...

        #endregion ...Events...

        #region ... Constructor...
        /// <summary>
        /// Initializes a new instance of the <see cref="MusicStore"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public EntityRepository(DbContext context)
        {
            mContext = context;
        }
        #endregion ...Constructor...

        #region ... Properties ...

        #endregion ...Properties...

        #region ... Methods    ...

        #endregion ...Methods...

        #region ... Interfaces ...

        #region Members
        /// <summary>
        /// Gets queryable of <typeparamref name="TEntity"/>
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        public IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class, new()
        {
            return mContext.Set<TEntity>();
        }
        /// <summary>
        /// Adds <typeparamref name="TEntity"/>
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        public void Add<TEntity>(TEntity entity) where TEntity : class, new()
        {
            mContext.Add(entity);
            //mContext.Set<TEntity>( ).Add( entity );
        }
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entities">The entities.</param>
        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, new()
        {
            mContext.AddRange(entities);
        }
        /// <summary>
        /// Deletes <typeparamref name="TEntity"/>
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        public void Delete<TEntity>(TEntity entity) where TEntity : class, new()
        {
            mContext.Set<TEntity>().Remove(entity);
        }
        /// <summary>
        /// Updates the specified to update.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="toUpdate">To update.</param>
        /// <param name="update">The update.</param>
        public void Update<TEntity>(TEntity toUpdate,Action<TEntity> update) where TEntity : class, new()
        {
            update(toUpdate);
        }
        /// <summary>
        /// Saves the changes.
        /// </summary>
        public int SaveChanges()
        {
            var rows = mContext.SaveChanges();
            return rows;
        }
        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if(mContext != null)
            {
                mContext.Dispose();
                mContext = null;
            }
        }

        #endregion

        #endregion ...Interfaces...
    }
}
