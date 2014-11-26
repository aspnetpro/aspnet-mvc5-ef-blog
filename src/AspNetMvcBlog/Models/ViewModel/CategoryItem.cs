using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvcBlog.Models.ViewModel
{
    public class CategoryItem
    {
        public string Permalink { get; set; }
        public string Name { get; set; }
        public int TotalPosts { get; set; }
    }
}