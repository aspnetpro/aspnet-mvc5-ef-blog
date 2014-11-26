using AspNetMvcBlog.Application;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcBlog.Areas.Admin.Controllers
{
    public class UploadController : Controller
    {
        public ActionResult Index(HttpPostedFileBase file)
        {
            string fileName = String.Concat(Path.GetRandomFileName().ToSlug(), Path.GetExtension(file.FileName));
            string fileLink = new AzureBlobStorageImpl().Upload(fileName, file.InputStream);

            var model = new
            {
                filelink = fileLink,
                title = fileName
            };

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}