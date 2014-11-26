using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNetMvcBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            string[] namespaces = new string[] {
                "AspNetMvcBlog.Controllers"
            };

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Posts.GetAll",
                url: "",
                defaults: new { controller = "Posts", action = "GetAll" },
                namespaces: namespaces
            );
            routes.MapRoute(
                name: "Posts.GetByCategory",
                url: "category/{category}",
                defaults: new { controller = "Posts", action = "GetByCategory", category = UrlParameter.Optional },
                namespaces: namespaces
            );
            routes.MapRoute(
                name: "Posts.Search",
                url: "search",
                defaults: new { controller = "Posts", action = "Search" },
                namespaces: namespaces
            );
            routes.MapRoute(
                name: "Posts.Details",
                url: "post/{permalink}",
                defaults: new { controller = "Posts", action = "Details" },
                namespaces: namespaces
            );
            routes.MapRoute(
                name: "Posts.LoadComments",
                url: "post/{permalink}/load-comments",
                defaults: new { controller = "Posts", action = "LoadComments" },
                namespaces: namespaces
            );
            routes.MapRoute(
                name: "Posts.AddComment",
                url: "post/{postId}/add-comment",
                defaults: new { controller = "Posts", action = "AddComment" },
                namespaces: namespaces
            );

            routes.MapRoute(
                name: "Sidebar.Categories",
                url: "sidebar/categories",
                defaults: new { controller = "Sidebar", action = "Categories" },
                namespaces: namespaces
            );

            routes.MapRoute(
                name: "Contact.Index",
                url: "contact",
                defaults: new { controller = "Contact", action = "Index" },
                namespaces: namespaces
            );
        }
    }
}
