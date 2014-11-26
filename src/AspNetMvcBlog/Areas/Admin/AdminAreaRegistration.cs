using System.Web.Mvc;

namespace AspNetMvcBlog.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get { return "Admin"; }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            string[] namespaces = new string[] {
                "AspNetMvcBlog.Areas.Admin.Controllers"
            };

            context.MapRoute(
                name: "Admin.Auth.LogOn",
                url: "admin",
                defaults: new { controller = "Auth", action = "LogOn" },
                namespaces: namespaces
            );
            context.MapRoute(
                name: "Admin.Auth.LogOut",
                url: "admin/logout",
                defaults: new { controller = "Auth", action = "LogOut" },
                namespaces: namespaces
            );

            context.MapRoute(
                name: "Admin.Dashboard.Index",
                url: "admin/dashboard",
                defaults: new { controller = "Dashboard", action = "Index" },
                namespaces: namespaces
            );
            context.MapRoute(
                name: "Admin.Posts.Index",
                url: "admin/posts",
                defaults: new { controller = "Posts", action = "Index" },
                namespaces: namespaces
            );
            context.MapRoute(
                name: "Admin.Posts.List",
                url: "admin/posts/list",
                defaults: new { controller = "Posts", action = "List" },
                namespaces: namespaces
            );
            context.MapRoute(
                name: "Admin.Posts.Add",
                url: "admin/posts/add",
                defaults: new { controller = "Posts", action = "Add" },
                namespaces: namespaces
            );
            context.MapRoute(
                name: "Admin.Posts.Edit",
                url: "admin/posts/edit/{id}",
                defaults: new { controller = "Posts", action = "Edit" },
                namespaces: namespaces
            );
            context.MapRoute(
                name: "Admin.Posts.Save",
                url: "admin/posts/save",
                defaults: new { controller = "Posts", action = "Save" },
                namespaces: namespaces
            );
            context.MapRoute(
                name: "Admin.Posts.Delete",
                url: "admin/posts/delete/{id}",
                defaults: new { controller = "Posts", action = "Delete" },
                namespaces: namespaces
            );

            context.MapRoute(
                name: "Admin.Upload.Index",
                url: "admin/upload/send",
                defaults: new { controller = "Upload", action = "Index" },
                namespaces: namespaces
            );

            context.MapRoute(
                name: "Admin.Autocomplete.Categories",
                url: "admin/autocomplete/categories",
                defaults: new { controller = "Autocomplete", action = "Categories" },
                namespaces: namespaces
            );
        }
    }
}