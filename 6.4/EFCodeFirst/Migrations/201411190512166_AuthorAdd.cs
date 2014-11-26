namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Articles", "AuthorId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "AuthorId");
            DropTable("dbo.Authors");
        }
    }
}
