using AspNetMvcBlog.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvcBlog.Models.ViewModel
{
    public class PostDetail
    {
        public Post Post { get; set; }
        public int TotalComments { get; set; }

        public IEnumerable<string> GetTags()
        {
            if (String.IsNullOrWhiteSpace(Post.Tags))
            {
                return Enumerable.Empty<string>();
            }

            return Post.Tags.Split(',');
        }
    }
}