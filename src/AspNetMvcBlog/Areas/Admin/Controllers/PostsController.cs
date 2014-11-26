using AspNetMvcBlog.Areas.Admin.Models;
using AspNetMvcBlog.Data;
using AspNetMvcBlog.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using AspNetMvcBlog.Application;
using System.Runtime.Caching;

namespace AspNetMvcBlog.Areas.Admin.Controllers
{
    public class PostsController : AdminController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(jQueryDataTableRequestModel request)
        {
            var contex = new BlogContext();
            IQueryable<Post> posts = contex.Posts.OrderByDescending(x => x.PublishedOn);

            if (!String.IsNullOrWhiteSpace(request.sSearch))
            {
                posts = posts.Where(x =>
                            x.Title.Contains(request.sSearch) ||
                            x.Summary.Contains(request.sSearch)
                        );
            }

            int total = posts.Count();
            posts = posts.Skip(request.iDisplayStart).Take(request.iDisplayLength);

            var model = new jQueryDataTableResponseModel
            {
                sEcho = request.sEcho,
                iTotalRecords = total,
                iTotalDisplayRecords = total,
                aaData = from r in posts.ToList()
                         select new
                         {
                             PostId = r.Id,
                             Title = r.Title,
                             PublishedOn = r.PublishedOn.ToString("dd/MM/yyyy"),
                             EditUrl = Url.RouteUrl("Admin.Posts.Edit", new { id = r.Id }),
                             DeleteUrl = Url.RouteUrl("Admin.Posts.Delete", new { id = r.Id })
                         }
            };

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            var model = new PostModel();
            return View("AddOrEdit", model);
        }

        public ActionResult Edit(int id)
        {
            var context = new BlogContext();

            var post = context.Posts
                .Include(x => x.Category)
                .FirstOrDefault(x => x.Id == id);
            if (post == null)
            {
                return HttpNotFound();
            }

            var model = PreparePostModel(post);

            return View("AddOrEdit", model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(PostModel model)
        {
            var context = new BlogContext();

            Post post = null;
            if (model.PostId == 0)
            {
                post = new Post();
                post.Permalink = model.Title.ToSlug();
            }
            else
            {
                post = context.Posts.FirstOrDefault(x => x.Id == model.PostId);
            }
            post.Title = model.Title;
            post.Summary = model.Summary;
            post.Content = model.Content;
            post.Tags = model.Tags;

            if (!String.IsNullOrWhiteSpace(model.Category))
            {
                string permalink = model.Category.ToSlug();
                post.Category = context.Categories.FirstOrDefault(x => x.Permalink == permalink);
                if (post.Category == null)
                {
                    post.Category = new Category
                    {
                        Name = model.Category,
                        Permalink = permalink
                    };
                }
            }
            else
            {
                post.Category = null;
            }

            try
            {
                if (model.PostId == 0)
                {
                    context.Posts.Add(post);    
                }
                else
                {
                    context.Entry(post).State = EntityState.Modified;
                    //removendo o item do cache
                    MemoryCache.Default.Remove("post-" + post.Permalink);
                }

                context.SaveChanges();

                Success("Your post has been saved");
            }
            catch (Exception)
            {
                Error("Your post cannot saved");
            }

            return RedirectToAction("Edit", new { id = post.Id });
        }

        public ActionResult Delete(int id)
        {
            var context = new BlogContext();

            var post = context.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            var model = PreparePostModel(post);

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            var context = new BlogContext();

            var post = context.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            context.Posts.Remove(post);
            context.SaveChanges();

            Success("Post deleted!");

            return RedirectToAction("Index");
        }

        [NonAction]
        private static PostModel PreparePostModel(Post post)
        {
            var model = new PostModel();
            model.PostId = post.Id;
            model.Permalink = post.Permalink;
            model.Title = post.Title;
            model.Summary = post.Summary;
            model.Content = post.Content;
            model.Tags = post.Tags;
            if (post.Category != null)
            {
                model.Category = post.Category.Name;    
            }
            return model;
        }
    }
}