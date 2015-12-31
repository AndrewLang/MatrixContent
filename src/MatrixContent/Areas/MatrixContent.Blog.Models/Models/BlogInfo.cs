using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixContent.Blog.Models
{
    public class BlogInfo
    {
        public string BlogId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string XmlRpc { get; set; }
        public bool IsAdmin { get; set; }
    }
}
