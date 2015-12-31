using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Models;

namespace MatrixContent.Blog.Models
{
    public class SocialAccount :Entity
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public bool IsPublic { get; set; }
        public bool SupportXmlrpc { get; set; }
        public bool PublishTo { get; set; }
    }
}
