using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcBlog.Application
{
    public class BaseController : Controller
    {
        const string MSG_SUCCESS = "MSG_SUCCESS";
        const string MSG_ERROR = "MSG_ERROR";

        protected void Success(string message)
        {
            TempData[MSG_SUCCESS] = message;
        }

        protected void Error(string message)
        {
            TempData[MSG_ERROR] = message;
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            ViewBag.SUCCESS = TempData[MSG_SUCCESS];
            ViewBag.ERROR = TempData[MSG_ERROR];

            base.OnResultExecuting(filterContext);
        }
    }
}