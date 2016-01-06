using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixContent.Blog.Models
{
    public class PostCategory
    {
        public int PostID { get; set; }
        public int CategoryID { get; set; }
        public Post Post { get; set; }
        public Category Category { get; set; }
    }
}
