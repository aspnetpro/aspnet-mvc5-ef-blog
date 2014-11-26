using AspNetMvcBlog.Data;
using AspNetMvcBlog.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcBlog.Controllers
{
    public class SidebarController : Controller
    {
        [ChildActionOnly]
        public ActionResult Categories()
        {
            var context = new BlogContext();

            var model = from c in context.Categories
                        select new CategoryItem
                        {
                            Permalink = c.Permalink,
                            Name = c.Name,
                            TotalPosts = c.Posts.Count()
                        };

            return PartialView("_Categories", model);
        }
    }
}