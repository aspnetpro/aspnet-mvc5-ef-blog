using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvcBlog.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Permalink { get; set; }
        public string Name { get; set; }

        public ICollection<Post> Posts
        {
            get { return _posts ?? (_posts = new List<Post>()); }
            set { _posts = value; }
        }
        ICollection<Post> _posts;
    }
}