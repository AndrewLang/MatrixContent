using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixContent.Blog.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class BlogLinks
    {
        public const string RsdAttribute = "EditURI";
        public const string ManifestAttribute = "wlwmanifest";
        public const string PingbackAttribute = "pingback";

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the RSD link.
        /// </summary>
        /// <value>
        /// The RSD link.
        /// </value>
        public string RsdLink { get; set; }
        /// <summary>
        /// Gets or sets the manifest link.
        /// </summary>
        /// <value>
        /// The manifest link.
        /// </value>
        public string ManifestLink { get; set; }
        /// <summary>
        /// Gets or sets the pingback link.
        /// </summary>
        /// <value>
        /// The pingback link.
        /// </value>
        public string PingbackLink { get; set; }
    }
}
