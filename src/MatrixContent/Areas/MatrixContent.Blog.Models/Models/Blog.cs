using MatrixContent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixContent.Blog.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Blog : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool ShowNameInTitle { get; set; }
        public bool ShowRelatedPosts { get; set; }
        public bool EnablePostRatings { get; set; }
        public bool EnableComments { get; set; }
        public bool ModerateComments { get; set; }
    }
}
