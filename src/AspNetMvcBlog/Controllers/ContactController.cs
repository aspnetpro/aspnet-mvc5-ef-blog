using AspNetMvcBlog.Models.FormModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcBlog.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactForm formModel)
        {
            var mail = new MailController();
            mail.Contact(formModel).Deliver();

            return View();
        }
    }
}