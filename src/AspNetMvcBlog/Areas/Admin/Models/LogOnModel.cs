using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvcBlog.Areas.Admin.Models
{
    public class LogOnModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}