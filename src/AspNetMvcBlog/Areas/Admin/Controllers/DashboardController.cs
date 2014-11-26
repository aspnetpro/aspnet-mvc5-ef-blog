using AspNetMvcBlog.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcBlog.Areas.Admin.Controllers
{
    public class DashboardController : AdminController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}