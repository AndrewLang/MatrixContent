using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Models;

namespace MatrixContent.Blog.Models
{
    /// <summary>
    /// Represent a link to some resource or web site
    /// </summary>
    public class Link : Entity
    {
        /// <summary>
        /// Gets or sets the name for display
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the URL of the link.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public int? Order { get; set; }
    }
}
