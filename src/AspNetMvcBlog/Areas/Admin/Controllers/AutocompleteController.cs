using AspNetMvcBlog.Application;
using AspNetMvcBlog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcBlog.Areas.Admin.Controllers
{
    public class AutocompleteController : AdminController
    {
        [OutputCache(CacheProfile="OneDay")]
        public ActionResult Categories(string term)
        {
            var context = new BlogContext();
            string slug = term.ToSlug();

            var model = context.Categories
                .Where(x => x.Permalink.StartsWith(slug))
                .Select(x => x.Name)
                .ToList();

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}