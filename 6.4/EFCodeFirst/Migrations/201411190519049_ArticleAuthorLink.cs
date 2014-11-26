namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticleAuthorLink : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.Articles SET AuthorId = 1 WHERE AuthorId IS NULL");
            AlterColumn("dbo.Articles", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "AuthorId");
            AddForeignKey("dbo.Articles", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Articles", new[] { "AuthorId" });
            AlterColumn("dbo.Articles", "AuthorId", c => c.Int());
        }
    }
}
