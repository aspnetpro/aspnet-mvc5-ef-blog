namespace AspNetMvcBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostTags : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Tags", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Tags");
        }
    }
}
