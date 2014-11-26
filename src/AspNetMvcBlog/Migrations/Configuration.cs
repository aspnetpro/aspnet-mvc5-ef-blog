namespace AspNetMvcBlog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AspNetMvcBlog.Data.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AspNetMvcBlog.Data.BlogContext context)
        {
            //context.Posts.Add(new Models.Entities.Post
            //{
            //    Permalink = "primeiro-post",
            //    Title = "Primeiro Post",
            //    Summary = "teste do primeiro post",
            //    Content = "bla bla bla"
            //});
        }
    }
}
