﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvcBlog.Models.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public DateTime PublishedOn { get; set; }
        public Post Post { get; set; }

        public Comment()
        {
            PublishedOn = DateTime.Now;
        }
    }
}