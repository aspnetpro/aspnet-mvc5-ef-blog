using ActionMailer.Net.Mvc;
using AspNetMvcBlog.Models.FormModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvcBlog.Controllers
{
    public class MailController : MailerBase
    {
        public EmailResult Contact(ContactForm model)
        {
            From = String.Format("{0} <{1}>", model.Name, model.Email);
            To.Add("mbanagouro@outlook.com");
            Subject = "Contato recebido pelo blog";

            return Email("Contact", model);
        }
    }
}