using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Models;

namespace MatrixContent.Blog.Models
{
    /// <summary>
    /// Represent a post
    /// </summary>
    public class Post : Entity
    {
        #region ... Variables  ...

        #endregion ...Variables...

        #region ... Events     ...

        #endregion ...Events...

        #region ... Constructor...
        /// <summary>
        /// Constructor of <see cref="Post"/>
        /// </summary>
        public Post( )
        {
            Tags = new List<Tag>( );
            Comments = new List<Comment>( );
            Categories = new List<Category>( );
            ReadCount = 0;
        }
        #endregion ...Constructor...

        #region ... Properties ...
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the html content of the post.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; }
        /// <summary>
        /// Gets or sets the slug.
        /// </summary>
        /// <value>
        /// The slug.
        /// </value>
        public string Slug { get; set; }
        /// <summary>
        /// Gets or sets the splash URL.
        /// </summary>
        /// <value>
        /// The splash URL.
        /// </value>
        public string SplashUrl { get; set; }
        /// <summary>
        /// Gets or sets the date published.
        /// </summary>
        /// <value>
        /// The date published.
        /// </value>
        public DateTime? DatePublished { get; set; }
        /// <summary>
        /// Gets or sets the date created
        /// </summary>
        /// <remarks>
        /// User can set the created date, just like old Window live space, thus the user can
        /// know which day the post record.
        /// </remarks>
        /// <value>The date created.</value>
        public DateTime? DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the date of last modified.
        /// </summary>
        /// <value>The date modified.</value>
        public DateTime? DateModified { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is public.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is public; otherwise, <c>false</c>.
        /// </value>
        public bool IsPublic { get; set; }
        //public bool IsDraft { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this post enable comments.
        /// </summary>
        /// <value><c>true</c> if enable comments user can leave comments on this post; otherwise, <c>false</c>.</value>
        public bool EnableComments { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is published.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is published; otherwise, <c>false</c>.
        /// </value>
        public bool IsPublished { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance has splash.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has splash; otherwise, <c>false</c>.
        /// </value>
        public bool HasSplash { get; set; }
        /// <summary>
        /// Gets or sets the read count.
        /// </summary>
        /// <value>
        /// The read count.
        /// </value>
        public int? ReadCount { get; set; }
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        public int? Rating { get; set; }
        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        /// <value>The user ID.</value>
        public int UserID { get; set; }
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public virtual ICollection<Comment> Comments { get; set; }
        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>The categories.</value>
        public virtual ICollection<Category> Categories { get; set; }
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>The tags.</value>
        public virtual ICollection<Tag> Tags { get; set; }
        #endregion ...Properties...

        #region ... Methods    ...

        #endregion ...Methods...

        #region ... Interfaces ...

        #endregion ...Interfaces...
    }
}
