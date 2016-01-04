using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixContent.Framework
{
    /// <summary>
    /// Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
    /// </summary>
    /// <remarks>
    /// Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
    /// </remarks>
    /// <typeparam name="T">The type of object the collection should contain.</typeparam>
    /// <seealso cref="IPagedList{T}"/>
    /// <seealso cref="List{T}"/>
    public class PagedList<T>:IPagedList<T>
    {
        #region ... Variables  ...
        readonly List<T> mInnerList = new List<T>();
        #endregion ...Variables...

        #region ... Events     ...

        #endregion ...Events...

        #region ... Constructor...
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class that divides the supplied superset into subsets the size of the supplied pageSize. The instance then only containes the objects contained in the subset specified by index.
        /// </summary>
        /// <param name="superset">The collection of objects to be divided into subsets. If the collection implements <see cref="IQueryable{T}"/>, it will be treated as such.</param>
        /// <param name="index">The index of the subset of objects to be contained by this instance.</param>
        /// <param name="pageSize">The maximum size of any individual subset.</param>
        /// <exception cref="ArgumentOutOfRangeException">The specified index cannot be less than zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified page size cannot be less than one.</exception>
        public PagedList(IEnumerable<T> superset,int index,int pageSize)
        {
            // set source to blank list if superset is null to prevent exceptions
            var source = superset == null
                                    ? new List<T>().AsQueryable()
                                    : superset.AsQueryable();

            TotalItemCount = source.Count();
            PageSize = pageSize;
            PageIndex = index;
            if(TotalItemCount > 0)
                PageCount = (int)Math.Ceiling(TotalItemCount / (double)PageSize);
            else
                PageCount = 0;

            if(index < 0)
#if !SILVERLIGHT
                throw new ArgumentOutOfRangeException("index",index,"PageIndex cannot be below 0.");
#else
                throw new ArgumentOutOfRangeException( "index", "PageIndex cannot be below 0." );
#endif
            if(pageSize < 1)
#if !SILVERLIGHT
                throw new ArgumentOutOfRangeException("pageSize",pageSize,"PageSize cannot be less than 1.");
#else
                throw new ArgumentOutOfRangeException( "pageSize", "PageSize cannot be less than 1." );
#endif

            // add items to internal list
            if(TotalItemCount > 0)
            {
                if(index == 0)
                    mInnerList.AddRange(source.Take(pageSize).ToList());
                else
                    mInnerList.AddRange(source.Skip((index) * pageSize).Take(pageSize).ToList());
            }
        }
        #endregion ...Constructor...

        #region ... Properties ...

        #endregion ...Properties...

        #region ... Methods    ...

        #endregion ...Methods...

        #region ... Interfaces ...
        #region IPagedList<T> Members
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public IList<T> Items
        {
            get
            {
                return mInnerList;
            }
        }
        /// <summary>
        /// Total number of subsets within the superset.
        /// </summary>
        /// <value>
        /// Total number of subsets within the superset.
        /// </value>
        public int PageCount { get; private set; }
        /// <summary>
        /// Total number of objects contained within the superset.
        /// </summary>
        /// <value>
        /// Total number of objects contained within the superset.
        /// </value>
        public int TotalItemCount { get; private set; }
        /// <summary>
        /// Zero-based index of this subset within the superset.
        /// </summary>
        /// <value>
        /// Zero-based index of this subset within the superset.
        /// </value>
        public int PageIndex { get; private set; }
        /// <summary>
        /// One-based index of this subset within the superset.
        /// </summary>
        /// <value>
        /// One-based index of this subset within the superset.
        /// </value>
        public int PageNumber
        {
            get { return PageIndex + 1; }
        }
        /// <summary>
        /// Maximum size any individual subset.
        /// </summary>
        /// <value>
        /// Maximum size any individual subset.
        /// </value>
        public int PageSize { get; private set; }
        /// <summary>
        /// Returns true if this is NOT the first subset within the superset.
        /// </summary>
        /// <value>
        /// Returns true if this is NOT the first subset within the superset.
        /// </value>
        public bool HasPreviousPage
        {
            get { return PageIndex > 0; }
        }
        /// <summary>
        /// Returns true if this is NOT the last subset within the superset.
        /// </summary>
        /// <value>
        /// Returns true if this is NOT the last subset within the superset.
        /// </value>
        public bool HasNextPage
        {
            get { return PageIndex < (PageCount - 1); }
        }
        /// <summary>
        /// Returns true if this is the first subset within the superset.
        /// </summary>
        /// <value>
        /// Returns true if this is the first subset within the superset.
        /// </value>
        public bool IsFirstPage
        {
            get { return PageIndex <= 0; }
        }
        /// <summary>
        /// Returns true if this is the last subset within the superset.
        /// </summary>
        /// <value>
        /// Returns true if this is the last subset within the superset.
        /// </value>
        public bool IsLastPage
        {
            get { return PageIndex >= (PageCount - 1); }
        }
        #endregion
        #endregion ...Interfaces...
    }
}
