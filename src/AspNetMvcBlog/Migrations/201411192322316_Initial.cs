namespace AspNetMvcBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Permalink = c.String(nullable: false, maxLength: 100),
                        Title = c.String(nullable: false, maxLength: 70),
                        Summary = c.String(nullable: false, maxLength: 500),
                        Content = c.String(),
                        PublishedOn = c.DateTime(nullable: false),
                    })
                .Index(x => x.Permalink)
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Posts");
        }
    }
}
