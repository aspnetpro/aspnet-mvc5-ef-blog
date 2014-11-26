namespace AspNetMvcBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostsComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Content = c.String(),
                        PublishedOn = c.DateTime(nullable: false),
                        Post_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostsComments", "Post_Id", "dbo.Posts");
            DropIndex("dbo.PostsComments", new[] { "Post_Id" });
            DropTable("dbo.PostsComments");
        }
    }
}
