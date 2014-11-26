using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvcBlog.Areas.Admin.Models
{
    public class PostModel
    {
        public int PostId { get; set; }
        public string Permalink { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
    }
}